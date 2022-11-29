using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapper;
namespace TP09.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-PHZ2-CIDI-029;DataBase=Qatar2022;Trusted_Connection=True;";
        private static List<Personaje> _ListadoPersonaje = new List<Personaje>();
        private static List<Libro> _ListadoLibros = new List<Libro>();
        private static List<calificacion> _ListadoCalificacion = new List<calificacion>();
        private static List<Usuario> _ListadoUsuario = new List<Usuario>();
        private static List<Libro> _ListadoLibrosBiblioteca = new List<Libro>();
        private static List<calificacion> _Comentarios = new List<calificacion>();

        public static Usuario UsuarioLogueado = null;
        private static bool haySesionAbierta = false;

        public static string NombraImagen()
        {
            return UsuarioLogueado.FotoDePerfil;
        }
        public static bool HaySesion()
        {
            return haySesionAbierta;
        }
        public static bool haypersonaje(int IdLibro)
        {
            Libro librohay;
            bool s = false;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Personajes WHERE IdLibro = @pLibro";
                librohay = BD.QueryFirstOrDefault<Libro>(sql, new {pLibro = IdLibro});
            }
            if(librohay != null)
            {
                s = true;
            }
            return s;
        }
        public static bool InicioSesion(Usuario usu)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Usuario WHERE Mail = @pMail AND Contraseña= @pContraseña";
                UsuarioLogueado = BD.QueryFirstOrDefault<Usuario>(sql, new {pMail = usu.Mail, pContraseña = usu.Contraseña});
            }
            if(UsuarioLogueado != null)
            {
                haySesionAbierta = true;
            }
            return haySesionAbierta;
        }
        public static List<Usuario> CrearUsuario(Usuario usu)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO Usuario(Nombre, Apellido, NombreDeUsuario, Contraseña, Activo, Mail, FechaDeCumplaños, PermisoDeEditor, FotoDePerfil) VALUES (@pNombre, @pApellido, @pNombreDeUsuario, @pContraseña, @pActivo, @pMail, @pFechaDeCumplaños, @pPermisoDeEditor, NULL);";
                _ListadoUsuario = BD.Query<Usuario>(sql, new {pNombre = usu.Nombre, pApellido = usu.Apellido, pNombreDeUsuario = usu.NombreDeUsuario, pContraseña=usu.Contraseña, pActivo=1, pMail=usu.Mail, pFechaDeCumplaños=usu.FechaDeCumplaños, pPermisoDeEditor=0, pFotoDePerfil=0}).ToList();
            }
            UsuarioLogueado = usu;
            haySesionAbierta = true;
            return _ListadoUsuario;
        }
        public static void ModificarUsuario(Usuario usu)
        {
            int nose;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "UPDATE Usuario SET NombreDeUsuario =  @pNombreDeUsuario, FotoDePerfil = @pFotoDePerfil WHERE IdUsuario = @pIdUsuario;";
                nose = BD.Execute(sql, new {pNombreDeUsuario = usu.NombreDeUsuario, pFotoDePerfil = usu.FotoDePerfil, pIdUsuario = usu.IdUsuario});
            }
        }
        public static List<Personaje> AgregarPersonaje(Personaje Pers)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO Personajes(IdLibro, Nombre, FechaNacimiento, Foto, Descripcion, Estado, Genero, Nacionalidad) VALUES (@pIdLibro, @pNombre, @pFechaNacimiento, @pFoto, @pDescripcion, @pEstado, @pGenero, @pNacionalidad);";
                _ListadoPersonaje = BD.Query<Personaje>(sql, new {pIdLibro = Pers.IdLibro, pNombre = Pers.Nombre, pFechaNacimiento=Pers.FechaNacimiento, pFoto=Pers.Foto, pDescripcion=Pers.Descripcion, pEstado=Pers.Estado, pGenero=Pers.Genero, pNacionalidad=Pers.Nacionalidad}).ToList();
            }
            return _ListadoPersonaje;
        }
        public static List<Libro> AgregarLibro(Libro Lib)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO Libros(Nombre, Portada, Contraportada, Autor, CantPaginas, Descripción, TW, CantLibros, Generos, Categoria, GeneroPrincipal) VALUES (@pNombre, @pPortada, @pContraportada, @pAutor, @pCantPaginas, @pDescripción, @pTW, @pCantLibros,  @pGeneros, @pCategoria, @pGeneroPrincipal);";
                _ListadoLibros = BD.Query<Libro>(sql, new {pNombre = Lib.Nombre, pPortada=Lib.Portada, pContraportada=Lib.Contraportada, pAutor=Lib.Autor, pCantPaginas=Lib.CantPaginas, pDescripción=Lib.Descripción, pTW=Lib.TW, pCantLibros=Lib.CantLibros, pGeneros=Lib.Generos, pCategoria=Lib.Categoria, pGeneroPrincipal=Lib.GeneroPrincipal}).ToList();
            }
            return _ListadoLibros;
        }
        
        public static int EliminarLibro(int pIdLibro)
        {
            int RegistrosEliminados = 0;
            string sp = "EliminarUnLibro";
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                RegistrosEliminados = BD.Execute(sp, new {IdLibro = pIdLibro},  commandType: CommandType.StoredProcedure);
            }
            return RegistrosEliminados;
        }
        public static int EliminarPersonaje(int IdPersonaje)
        {
            int RegistrosEliminados = 0;
            string sql = "DELETE FROM Personajes WHERE IdPersonaje = @bPersonaje";
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                RegistrosEliminados = BD.Execute(sql, new {bPersonaje = IdPersonaje });
            }
            return RegistrosEliminados;
        }
        public static int EliminardeGuardado(int idUsuario, int IdLibro)
        {
            int RegistrosEliminados = 0;
            string sql = "DELETE FROM biblioteca WHERE IdUsuario = @pIdUsuario and IdLibro = @pIdLibro";
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                RegistrosEliminados = BD.Execute(sql, new {pIdUsuario = idUsuario, pIdLibro = IdLibro});
            }
            return RegistrosEliminados;
        }
        public static bool haylibrosguardadosensuperfil(int idUsuario)
        {
            bool estabaguardado = false;
            Biblioteca MiLibro;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM biblioteca WHERE IdUsuario = @pIdUsuario";
                MiLibro = BD.QueryFirstOrDefault<Biblioteca>(sql, new {pIdUsuario = idUsuario});
            }
            if(MiLibro == null)
            {
                estabaguardado = false;
            }
            else{
                estabaguardado = true;
            }
            return estabaguardado;
        }
        public static bool yaestabaguardado(int idUsuario, int IdLibro)
        {
            bool estabaguardado = false;
            Biblioteca MiLibro;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM biblioteca WHERE IdUsuario = @pIdUsuario and IdLibro = @pIdLibro";
                MiLibro = BD.QueryFirstOrDefault<Biblioteca>(sql, new {pIdUsuario = idUsuario, pIdLibro = IdLibro});
            }
            if(MiLibro == null)
            {
                estabaguardado = false;
            }
            else{
                estabaguardado = true;
            }
            return estabaguardado;
        }
        public static Libro VerInfoLibro(int IdLibro)
        {
            Libro MiLibro;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Libros WHERE IdLibro = @libroselect";
                MiLibro = BD.QueryFirstOrDefault<Libro>(sql, new { libroselect = IdLibro});
            }
            return MiLibro;
        }
        public static List<Libro> ListarLibrosdeBiblioteca(int pidusuario)
        {
            string sp = "sp_ListarLibrosGuardados";
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                _ListadoLibrosBiblioteca = BD.Query<Libro>(sp, new {IdUsuario = pidusuario},  commandType: CommandType.StoredProcedure).ToList();
            }
            return _ListadoLibrosBiblioteca;
        }

        public static Biblioteca GuardarLibro(int idUsuario, int IdLibro)
        {
            Biblioteca MiLibro;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO biblioteca(IdUsuario, IdLibro) values (@pIdUsuario, @pIdLibro)";
                MiLibro = BD.QueryFirstOrDefault<Biblioteca>(sql, new {pIdUsuario = idUsuario, pIdLibro = IdLibro});
            }
            return MiLibro;
        }
        public static Personaje VerInfoPersonaje(int IdPersonaje)
        {
            Personaje InfoPersonaje;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Personajes WHERE IdPersonaje = @personajeselect";
                InfoPersonaje = BD.QueryFirstOrDefault<Personaje>(sql, new { personajeselect = IdPersonaje});
            }
            return InfoPersonaje;
        }
        public static List<Libro> ListarLibros()
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Libros";
                _ListadoLibros = BD.Query<Libro>(sql).ToList();
            }
            return _ListadoLibros;
        }
        public static List<Personaje> ListarPersonajes(int IdLibro)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Personajes WHERE IdLibro = @libroselect";
                _ListadoPersonaje = BD.Query<Personaje>(sql, new {libroselect = IdLibro}).ToList();
            }
            return _ListadoPersonaje;
        }
        public static List<calificacion> ListarComentarios(int IdLibro)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Calificaciones WHERE IdLibro = @libroselect";
                _Comentarios = BD.Query<calificacion>(sql, new {libroselect = IdLibro}).ToList();
            }
            return _Comentarios;
        }
        public static List<calificacion> calificacionLibroAjax(calificacion cal)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO calificaciones(IdLibro, IdUsuario, Comentarios, Estrellas) values (@pIdLibro, @pIdUsuario, @pComentarios, @plikes)";
                _ListadoCalificacion = BD.Query<calificacion>(sql, new {pIdLibro = cal.IdLibro, pIdUsuario = cal.IdUsuario, plikes = cal.Estrellas, pComentarios = cal.Comentarios}).ToList();
            }
            return _ListadoCalificacion;
        }
        public static void CerrarSesion()
        {
            haySesionAbierta = false;
            UsuarioLogueado = null;
        }
    }
}