using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteQueryBrowser;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Globalization;

namespace CodeMaster
{
    class CodeMassManager
    {
        static string path;//="D:/CodeMass.db3";
        SQLiteDBHelper db;
        List<List<string>> list=new List<List<string>>();

        string GetCurrentPath()
        {
            string str = this.GetType().Assembly.Location;
            str = str.Substring(0, str.LastIndexOf("\\")) + "\\Data";
            if (!Directory.Exists(str)) Directory.CreateDirectory(str);
            str += "\\CodeMass.db3";
            return str;
        }

        void GetDataBase()
        {
            path = GetCurrentPath();
            if (File.Exists(path))
            {
                db = new SQLiteDBHelper(path);
            }
            else
            {
                SQLiteDBHelper.CreateDB(path);
                db = new SQLiteDBHelper(path);
                string sql = "CREATE TABLE CodeMass(ID integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                                    "CodeName char(40)," +
                                                    "Language char(3)," +
                                                    "Comments varchar(100),"+
                                                    "AddTime datetime,UpdateTime Date," +
                                                    "Source_Code Text)";
                db.ExecuteNonQuery(sql, null);
            }

        }

        public void InsertData(string name, string language, string code, string comments)
        {
            string sql = "INSERT INTO CodeMass(CodeName,Language,Comments,AddTime,UpdateTime,Source_Code)values(@CodeName,@Language,@Comments,@AddTime,@UpdateTime,@Source_Code)";
            SQLiteDBHelper db = new SQLiteDBHelper(path);
            SQLiteParameter[] parameters = new SQLiteParameter[]{ 
                                                 new SQLiteParameter("@CodeName",name), 
                                                 new SQLiteParameter("@Language",language),  
                                                 new SQLiteParameter("@Comments",comments),
                                                 new SQLiteParameter("@AddTime",DateTime.Now), 
                                                 new SQLiteParameter("@UpdateTime",DateTime.Now.Date),                                                 
                                                 new SQLiteParameter("@Source_Code",code)
                                         };
            db.ExecuteNonQuery(sql, parameters);
        }

        public void UpdateData(int id, string name)
        {
            //string sql = String.Format("update CodeMass set CodeName='{0}',Comments='{1}',UpdateTime={2},Source_Code='{3}' where ID={4} ", name, comments, DateTime.Now.Date, code, id);

            string sql = "UPDATE CodeMass Set CodeName=@CodeName where ID=" + id.ToString();
            SQLiteDBHelper db = new SQLiteDBHelper(path);

            SQLiteParameter[] parameters = new SQLiteParameter[]{                                                                   
                                                 new SQLiteParameter("@CodeName",name), 
                                         };
            db.ExecuteNonQuery(sql, parameters);
        }
        

        public void UpdateData(int id,string name, string code, string comments)
        {
            //string sql = String.Format("update CodeMass set CodeName='{0}',Comments='{1}',UpdateTime={2},Source_Code='{3}' where ID={4} ", name, comments, DateTime.Now.Date, code, id);

            string sql = "UPDATE CodeMass Set CodeName=@CodeName,Comments=@Comments,UpdateTime=@UpdateTime,Source_Code=@Source_Code where ID=" + id.ToString();
            SQLiteDBHelper db = new SQLiteDBHelper(path);
            
            SQLiteParameter[] parameters = new SQLiteParameter[]{                                                                   
                                                 new SQLiteParameter("@CodeName",name), 
                                                 new SQLiteParameter("@Comments",comments),
                                                 new SQLiteParameter("@UpdateTime",DateTime.Now.Date), 
                                                 new SQLiteParameter("@Source_Code",code)
                                         };
            db.ExecuteNonQuery(sql, parameters);
        }

        public string ShowData(string sql)
        {
            //Search Record 
            //string sql = "select * from test3 order by id";
            SQLiteDBHelper db = new SQLiteDBHelper(path);
            string outS="";

            using (SQLiteDataReader reader = db.ExecuteReader(sql, null))
            {
                while (reader.Read())
                {
                    outS = outS + reader.GetInt64(0).ToString() + " " + reader.GetString(1) + " " + reader.GetString(6);
                    //Console.WriteLine("ID:{0},TypeName{1}", reader.GetInt64(0), reader.GetString(1));
                }
            }
            return outS;
        }

        private string ChangeStrToLikeStr(string str)
        {
            str.Replace(" ", "%");
            return str;

        }

        public DataSet GetDataByQuery(string search)
        {
            CompareInfo Compare = CultureInfo.InvariantCulture.CompareInfo;

            SQLiteDBHelper db = new SQLiteDBHelper(path);
            string outS = "(";
            bool flag = false;
            search = search.Replace(" ", "");
            using (SQLiteDataReader reader = db.ExecuteReader("select ID,CodeName,Comments from CodeMass order by id", null))
            {
                while (reader.Read())
                {
                    if ((Compare.IndexOf(reader.GetString(1).Replace(" ", ""), search, CompareOptions.IgnoreCase) != -1) ||
                        (Compare.IndexOf(reader.GetString(2).Replace(" ", ""), search, CompareOptions.IgnoreCase) != -1))
                    {
                        outS = outS + reader.GetInt64(0).ToString() + ",";
                        flag = true;
                    }
                }
                if (flag) outS = outS.Substring(0, outS.Length - 1) + ")";
                else outS="(-1,-2)";
            }

            String connectionString = "Data Source=" + path;
            //String selectCommand = "Select ID, CodeName,Language,AddTime,UpdateTime,Source_Code,Comments from CodeMass";
            //String selectCommand = "select * from CodeMass where CodeName like '%"+ChangeStrToLikeStr(search) + "%'";
            String selectCommand = "select * from CodeMass where ID in " + outS;
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connectionString);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "T_CLASS");
            return ds;

        }

        public DataSet GetDataByQuery()
        {
            String connectionString = "Data Source=" + path;
            //String selectCommand = "Select ID, CodeName,Language,AddTime,UpdateTime,Source_Code,Comments from CodeMass";
            String selectCommand = "select * from CodeMass order by id";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connectionString);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "T_CLASS");
            return ds;
        }

        public bool IfExist(string Code_name)
        {
            //string sql = "select * from CodeMass where LOWER()";
            return true;
        }

        public void DeleteByID(int id)
        {
            string sql = "delete from CodeMass where ID="+id.ToString();
            SQLiteDBHelper db = new SQLiteDBHelper(path);
            db.ExecuteNonQuery(sql, null);
            return;
        }

        public void DeleteByName(string name)
        {
            string sql = "delete from CodeMass where CodeName=" + name;
            SQLiteDBHelper db = new SQLiteDBHelper(path);
            db.ExecuteNonQuery(sql, null);
            return;
        }

        public CodeMassManager()
        {
            //path = GetCurrentPath();
            GetDataBase();
        }
    }
}
