using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Kelime_Ezber_Sistemi
{
    class Sqlbaglantisi
    {
        public MySqlConnection bağlantı()
        {
            try
            {//server=sql289.main-hosting.eu;user id=u477970783_aykutik;database=u477970783_tanlas;Pwd=aykuT18092007; Charset = utf8
                string bağlantıadresi = "server=loyaz.net;user id=u477970783_kelimeezber; database=u477970783_kelimeezber; Pwd=aykuT18092007; Charset = utf8";
                //mysql://bdbb59f8e5a999:9e92108f@eu-cdbr-west-02.cleardb.net/heroku_35277f60d273b6a?reconnect=true
                //string bağlantıadresi = "server=eu-cdbr-west-02.cleardb.net;user id=bdbb59f8e5a999; database=heroku_35277f60d273b6a; Pwd=9e92108f";

                MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);


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
    