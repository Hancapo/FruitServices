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
	bool CrearUsuario(string email, string pass, string user);

	[OperationContract]
	string TraerDato(string dato, string tipo, string valor, string tabla);

	[OperationContract]
	bool ExisteInstancia(string referencia, string tabla, string tipo);

	[OperationContract]
	bool AgregarProducto(string nombre, string unidad, int stock, int precio);

}

