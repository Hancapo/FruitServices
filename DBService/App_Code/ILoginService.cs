using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


[ServiceContract]
public interface IService
{

	[OperationContract]
	bool VerificarAcceso(string nombreusuario, string pass);

	[OperationContract]
	bool CrearUsuario(string email, string pass, string user, string TipoU, string run);

	[OperationContract]
	string TraerDato(string dato, string tipo, string valor, string tabla);

	[OperationContract]
	bool ComprobarDato(string referencia, string tabla, string tipo);

	[OperationContract]
	bool AgregarProducto(string nombre, string unidad, int stock, int precio);

	[OperationContract]
	bool ActualizarDatoProductos(string nombre, int precio, int stock, string unidad, int id);

	[OperationContract]
	bool AgregarDomicilio(string calle, string ciudad, string comuna, int cp, int iduser, int numerodomi, string pais);

}

