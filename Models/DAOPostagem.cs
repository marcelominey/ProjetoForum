using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ProjetoForum.Models
{
    public class DAOPostagem
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source=.\sqlexpress;Initial Catalog=Forum;user id=sa;password=senai@123"; 
        
        public List<Postagem> Listar(){
            List<Postagem> postagem = new List<Postagem>();
            try{
                con = new SqlConnection(); //SqlConnection tem dois construtores. Vai fazer "por fora" msm
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Select * from tbl_postagem";
                
                rd = cmd.ExecuteReader();

                while(rd.Read()){ //ENQUANTO TIVER LINHA/CONTEÚDO PARA LER EM RD
                    
                    postagem.Add(new Postagem(){Id=rd.GetInt32(0), Idtopico=rd.GetInt32(1), Idusuario=rd.GetInt32(2), Mensagem=rd.GetString(3), Datapublicacao = rd.GetDateTime(4)});
                    //CLASSE POSTAGEM: MEIO DE PASSAGEM DE DADOS
                    //ADICIONANDO NESSA LISTA UMA NOVA POSTAGEM, GERADA ANONIMAMENTE(?)
                    //COLOCA OS DADOS DENTRO DELE
                    //ADICIONA NA LISTA (LISTA QUE SÓ RECEBE "POSTAGEM").
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
            return postagem;
        }
        public bool Cadastrar(Postagem postagem){
            bool rs = false;
            try{

            con = new SqlConnection(); //SqlConnection tem dois construtores. Vai fazer "por fora" msm
            con.ConnectionString = conexao;
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "INSERT INTO postagem(Idtopico,Idusuario,Mensagem) values(@n, @e, @h)";
            cmd.Parameters.AddWithValue("@n", postagem.Idtopico);
            cmd.Parameters.AddWithValue("@e", postagem.Idusuario);
            cmd.Parameters.AddWithValue("@h", postagem.Mensagem);
            
            int r = cmd.ExecuteNonQuery();

            if(r > 1)
                rs = true;
                
            cmd.Parameters.Clear();
                  
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar inserir os dados "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("erro inesperado "+ex.Message);
            }
            finally{
                con.Close();
            }
            return rs;
        }
    }
}