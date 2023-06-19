using System.Data.SqlClient;

namespace OpgaveBlazor.Data
{
    public class TestDBService
    {
        string Path = "Data Source=192.168.2.3;Initial Catalog=TestDB;User ID=sa;Password=Passw0rd;Connect Timeout=30;";

        public List<TestTable> ReadTestTable()
        {
            List<TestTable> list = new();
            using (SqlConnection con = new(Path))
            {
                SqlCommand cmd = new("SELECT * FROM TestTable", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TestTable item = new();
                    item.Id = (int)reader[0];
                    item.name = (string)reader[1];
                    list.Add(item);
                }
                con.Close();
            }
            return list;
        }
    }

}
