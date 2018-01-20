using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ProjetoForum.Models
{
    public class DAOUsuario
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source=.\sqlexpress;Initial Catalog=Forum;user id=sa;password=senai@123"; 
        
        public List<Usuario> Listar(){
            List<Usuario> usuario = new List<Usuario>();
            try{
                con = new SqlConnection(); //SqlConnection tem dois construtores. Vai fazer "por fora" msm
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Select * from tbl_usuario";
                
                rd = cmd.ExecuteReader();

                while(rd.Read()){ //ENQUANTO TIVER LINHA/CONTEÚDO PARA LER EM RD
                    
                    usuario.Add(new Usuario(){Idusuario=rd.GetInt32(0), Nome=rd.GetString(1), Login = rd.GetString(2), Senha = rd.GetString(3), Datacadastro = rd.GetDateTime(4)});
                    //CLASSE USUARIO: MEIO DE PASSAGEM DE DADOS
                    //ADICIONANDO NESSA LISTA UM NOVO USUARIO, GERADO ANONIMAMENTE(?)
                    //COLOCA OS DADOS DENTRO DELE
                    //ADICIONA NA LISTA (LISTA QUE SÓ RECEBE USUARIOS).
                }
            }
            catch(SqlException se){
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }
            return usuario;
        }
    }
}