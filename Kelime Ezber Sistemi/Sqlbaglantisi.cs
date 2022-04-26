using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Kelime_Ezber_Sistemi
{
    class Sqlbaglantisi
    {
        public MySqlConnection bağlantı()
        {
            try
            {//server=sql289.main-hosting.eu;user id=u477970783_aykutik;database=u477970783_tanlas;Pwd=aykuT18092007; Charset = utf8
                string bağlantıadresi = "server=loyaz.net;user id=u477970783_kelimeezber; database=u477970783_kelimeezber; Pwd=aykuT18092007; Charset = utf8";

                MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);

                if (bağlantı.State == ConnectionState.Open)
                {
                    Console.WriteLine("bağlanti başarılı");
                    bağlantı.Close();
                }

                bağlantı.Open();
                if (bağlantı.State == ConnectionState.Open)
                {
                    Console.WriteLine("bağlanti başarılı");
                }
                return bağlantı;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
    