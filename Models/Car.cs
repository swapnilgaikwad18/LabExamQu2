using System.Data.SqlClient;
using System.Data;

namespace LabExamQu2.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public int Bhp { get; set; }
        public int Cc { get; set; }
        public int FuelTank { get; set; }
        public decimal FuelEconomy { get; set; }

        public static List<Car> GetAllCars()
        {
            List<Car> lstcar = new List<Car>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Cars";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Car car = new Car();
                    car.CarId = dr.GetInt32("CarId");
                    car.Name = dr.GetString("Name");
                    car.Bhp = dr.GetInt32("Bhp");
                    car.Cc = dr.GetInt32("Cc");
                    car.FuelTank = dr.GetInt32("FuelTank");
                    car.FuelEconomy = dr.GetDecimal("FuelEconomy");
                    lstcar.Add(car);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstcar;
        }

        public static Car GetSingleCar(int CarId)
        {
            Car car = new Car();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True";
            cn.Open();

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Cars where CarId = @CarId";

                cmd.Parameters.AddWithValue("@CarId", CarId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    car.CarId = dr.GetInt32("CarId");
                    car.Name = dr.GetString("Name");
                    car.Bhp = dr.GetInt32("Bhp");
                    car.Cc = dr.GetInt32("Cc");
                    car.FuelTank = dr.GetInt32("FuelTank");
                    car.FuelEconomy = dr.GetDecimal("FuelEconomy");
                }
                else
                {
                    car = null;
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return car;
        }

        public static void InsertCar(Car car)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Cars values(@CarId, @Name, @Bhp, @Cc, @Fueltank, @FuelEconomy)";
                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@Name", car.Name);
                cmd.Parameters.AddWithValue("@Bhp", car.Bhp);
                cmd.Parameters.AddWithValue("@Cc", car.Cc);
                cmd.Parameters.AddWithValue("@FuelTank", car.FuelTank);
                cmd.Parameters.AddWithValue("@FuelEconomy", car.FuelEconomy);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateCar(Car car)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cars set CarId=@CarId, Name=@Name, Bhp=@Bhp, Cc=@Cc, FuelTank=@FuelTank, FuelEconomy=@FuelEconomy where CarId = @CarId";

                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@Name", car.Name);
                cmd.Parameters.AddWithValue("@Bhp", car.Bhp);
                cmd.Parameters.AddWithValue("@Cc", car.Cc);
                cmd.Parameters.AddWithValue("@FuelTank", car.FuelTank);
                cmd.Parameters.AddWithValue("@FuelEconomy", car.FuelEconomy);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }

        public static void DeleteCar(int CarId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Cars where CarId =@CarId";

                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }


    }
}
