using System;
namespace TP_09.Models
{
    public class Personaje
    {
        private int _IdPersonaje;
        private int _IdLibro;
        private string _Nombre;
        private DateTime _FechaNacimiento;
        private string _Foto;
        private string _Descripcion;
        private string _Estado;
        private string _Genero;
        private string _Nacionalidad;

        public Personaje(){}

        public Personaje(int IdPersonaje, int IdLibro, string Nombre, DateTime FechaNacimiento, string Foto, string Descripcion, string Estado, string Genero, string Nacionalidad){
            _IdPersonaje = IdPersonaje;
            _IdLibro = IdLibro;
            _Nombre = Nombre;
            _FechaNacimiento = FechaNacimiento;
            _Foto = Foto;
            _Descripcion = Descripcion;
            _Estado = Estado;
            _Genero = Genero;
            _Nacionalidad = Nacionalidad;
        }

        public int IdPersonaje{
            get {return _IdPersonaje;}
            set {_IdPersonaje = value;}
        }
        public int IdLibro{
            get {return _IdLibro;}
            set {_IdLibro = value;}
        }
        public string Nombre{
            get {return _Nombre;}
            set {_Nombre = value;}
        }
        public DateTime FechaNacimiento{
            get {return _FechaNacimiento;}
            set {_FechaNacimiento = value;}
        }
        public string Foto{
            get {return _Foto;}
            set {_Foto = value;}
        }
        public string Descripcion{
            get {return _Descripcion;}
            set {_Descripcion = value;}
        }
        public string Estado{
            get {return _Estado;}
            set {_Estado = value;}
        }
        public string Genero{
            get {return _Genero;}
            set {_Genero = value;}
        }
        public string Nacionalidad{
            get {return _Nacionalidad;}
            set {_Nacionalidad = value;}
        }
    }
}