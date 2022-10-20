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
        private static string _connectionString = @"Server=A-PHZ2-CIDI-042;DataBase=Qatar2022;Trusted_Connection=True;";
        private static List<Personaje> _ListadoPersonaje = new List<Personaje>();
        private static List<Libro> _ListadoLibros = new List<Libro>();
        private static List<calificacion> _ListadoCalificacion = new List<calificacion>();
        private static List<Usuario> _ListadoUsuario = new List<Usuario>();
        private static bool haySesionAbierta = false;

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
                string sql = "INSERT INTO Libros(Nombre, Portada, Contraportada, Autor, CantPaginas, Descripción, TW, CantLibros) VALUES (@pNombre, @pPortada, @pContraportada, @pAutor, @pCantPaginas, @pDescripción, @pTW, @pCantLibros);";
                _ListadoLibros = BD.Query<Libro>(sql, new {pNombre = Lib.Nombre, pPortada=Lib.Portada, pContraportada=Lib.Contraportada, pAutor=Lib.Autor, pCantPaginas=Lib.CantPaginas, pDescripción=Lib.Descripción, pTW=Lib.TW, pCantLibros=Lib.CantLibros}).ToList();
            }
            return _ListadoLibros;
        }
        public static List<Usuario> CrearUsuario(Usuario usu)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "INSERT INTO Usuario(Nombre, Apellido, NombreDeUsuario, Contraseña, Activo, Mail, HoraDeCreación, PermisoDeEditor, FotoDePerfil) VALUES (@pNombre, @pApellido, @pNombreDeUsuario, @pContraseña, @pActivo, @pMail, @pHoraDeCreación, @pPermisoDeEditor, @pFotoDePerfil);";
                _ListadoUsuario = BD.Query<Usuario>(sql, new {pNombre = usu.Nombre, pApellido = usu.Apellido, pNombreDeUsuario = usu.NombreDeUsuario, pContraseña=usu.Contraseña, pActivo=1, pMail=usu.Mail, pHoraDeCreación=DateTime.Today, pPermisoDeEditor=0, pFotoDePerfil=0}).ToList();
            }
            haySesionAbierta = true;
            return _ListadoUsuario;
        }
        public static bool HaySesion()
        {
            return haySesionAbierta;
        }
        public static Usuario VerPerfil(Usuario usu)
        {
            Usuario usua;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "SELECT * FROM Usuario WHERE IdUsuario = @pIdUsuario";
                usua = BD.QueryFirstOrDefault<Usuario>(sql, new {pIdUsuario = usu.IdUsuario});
            }
            return usua;
        }
        public static void ModificarUsuario(Usuario usu)
        {
            int nose;
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "UPDATE Usuario SET NombreDeUsurio =  @pNombreDeUsuario, FotoDePerfil = @pFotoDePerfil WHERE IdUsuario = @pIdUsuario);";
                nose = BD.Execute(sql, new {pNombreDeUsuario = usu.NombreDeUsuario, pFotoDePerfil = usu.FotoDePerfil, pIdUsuario = usu.IdUsuario});
            }
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
        public static int EliminarLibro(int IdLibro)
        {
            int RegistrosEliminados = 0;
            string sql = "DELETE FROM Libros WHERE IdLibro = @bLibro";
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                RegistrosEliminados = BD.Execute(sql, new {bLibro = IdLibro });
            }
            return RegistrosEliminados;
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

        public static List<calificacion> calificacionLibroAjax(calificacion cal)
        {
            using(SqlConnection BD = new SqlConnection(_connectionString)){
                string sql = "Insert into calificaciones(Comentarios, Estrellas) values (@pComantarios, @plikes)";
                _ListadoCalificacion = BD.Query<calificacion>(sql, new {pComentarios = cal.Comentarios, plikes = cal.Estrellas}).ToList();
            }
            return _ListadoCalificacion;
        }
    }
}