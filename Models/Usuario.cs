namespace TP09.Models
{
    public class Usuario
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Contraseña;
        private bool _Activo;
        private string _Mail;
        private DateTime _HoraDeCreación;
        private bool _PermisoDeEditor;
        private string _FotoDePerfil;

        public Usuario() {}

        public Usuario(int IdUsuario, string Nombre, string Contraseña,bool Activo, string Mail, DateTime HoraDeCreación, bool PermisoDeEditor, string FotoDePerfil){
            _IdUsuario = IdUsuario;
            _Nombre = Nombre;
            _Contraseña = Contraseña;
            _Activo = Activo;
            _Mail = Mail;
            _HoraDeCreación = HoraDeCreación;
            _PermisoDeEditor = PermisoDeEditor;
            _FotoDePerfil = FotoDePerfil;
        }

        public int IdUsuario{
            get {return _IdUsuario;}
            set {_IdUsuario = value;}
        }
        public string Nombre{
            get {return _Nombre;}
            set {_Nombre = value;}
        }
        public string Contraseña{
            get {return _Contraseña;}
            set {_Contraseña = value;}
        }
        public bool Activo{
            get {return _Activo;}
            set {_Activo = value;}
        }
        public string Mail{
            get {return _Mail;}
            set {_Mail = value;}
        }
        public DateTime HoraDeCreación{
            get {return _HoraDeCreación;}
            set {_HoraDeCreación = value;}
        }
        public bool PermisoDeEditor{
            get {return _PermisoDeEditor;}
            set {_PermisoDeEditor = value;}
        }
        public string FotoDePerfil{
            get {return _FotoDePerfil;}
            set {_FotoDePerfil = value;}
        }
    }
}