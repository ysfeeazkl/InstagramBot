using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidİnstaDeneme2
{
    public class Command
    {
        Baglanti baglanti = new Baglanti();

        public SqlCommand komut(string SqlCümlesi) // burası gelen komutu gönderiyo
        {
            SqlCommand command = new SqlCommand(SqlCümlesi, baglanti.BaglantiAc());
            return command;
        }
    }
}
