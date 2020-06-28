using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Instrumentation;

public class Service : IService
{

	

	readonly SqlConnection sc = new SqlConnection(@"Data Source=(Localdb)\tiendaduoc;Initial Catalog=Tienda;Integrated Security=true;");

	public bool VerificarAcceso(string nombreusuario, string pass)
	{
		sc.Open();
		SqlCommand sqc = new SqlCommand("SELECT * FROM dbo.Usuario WHERE nom_user = '" + nombreusuario + "' AND password = '" + pass + "';", sc);
		sqc.ExecuteNonQuery();
		DataTable dt = new DataTable();
		SqlDataAdapter sqa = new SqlDataAdapter(sqc);
		sqa.Fill(dt);

		if (dt.Rows.Count <= 0)
		{
			sc.Close();

			return false;
		}
		sc.Close();

		return true;
	}

	public bool AgregarDomicio(string calle, string ciudad, string comuna, int cp, int iduser, int numerodomi, string pais)
    {
		sc.Open();
		SqlCommand scf = new SqlCommand("INSERT INTO dbo.direccion(Calle,Ciudad,Comuna,cp,idUsuario,N_domic,Pais) VALUES ('Avenida Siempre Viva', 'Santiago', 'Puente Alto', 7845, 2, 1182, 'Chile');", sc);
		scf.ExecuteNonQuery();
		sc.Close();
		return true;
    }

	public bool CrearUsuario(string email, string pass, string user, string TipoU, string run)
	{
		if (!ComprobarDato(email, "dbo.Usuario", "email"))
		{
			SqlCommand ComandoUsuario = new SqlCommand("INSERT INTO dbo.Usuario (email, nom_user, password, run, TipoUsuario) VALUES ('" + email + "', '" + user + "', '" + pass + "', '" + run + "', 'user');", sc);
			ComandoUsuario.ExecuteNonQuery();

			sc.Close();

			return true;
		}
		else
		{
			sc.Close();

			return false;
		}


	}

	public string TraerDato(string dato, string tipo, string valor, string tabla)
	{
		sc.Open();
		SqlCommand TraerAlgo = new SqlCommand("SELECT " + dato + " from " + tabla + " WHERE " + tipo + "='" + valor + "'", sc);
		string datos = TraerAlgo.ExecuteScalar().ToString();
		sc.Close();

		return datos;
	}

	public bool ComprobarDato(string referencia, string tabla, string tipo)
	{
		sc.Open();
		SqlCommand command = new SqlCommand("Select id from " + tabla + " WHERE " + tipo + "='" + referencia + "'", sc);
		List<int> results = new List<int>();
		using (SqlDataReader reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				results.Add(Convert.ToInt32(reader[0]));
			}
		}

		
		if (results.Count == 0)
		{
			return false;
		}
		else
		{

			return true;

		}

	}

	public bool AgregarProducto(string nombre, string unidad, int stock, int precio)
	{

		if (!ComprobarDato(nombre, "dbo.Productos", "nom_prod"))
		{

			SqlCommand comando = new SqlCommand("insert into dbo.Productos (nom_prod, unidad, stock, Precio) values ('" + nombre + "', '" + unidad + "', " + stock + ", " + precio + ");", sc);

			comando.ExecuteNonQuery();
			return true;
		}
		else
		{

			return false;
		}

	}

	public bool ActualizarDatoProductos(string nombre, int precio, int stock, string unidad, int id)
    {
		sc.Open();
			SqlCommand sss = new SqlCommand("UPDATE dbo.Productos SET nom_prod = '" + nombre + "', precio = " + precio + ", stock = " + stock + ", unidad = '" + unidad + "' WHERE id = " + id, sc);
			sss.ExecuteNonQuery();
			return true;



    }
		
}
