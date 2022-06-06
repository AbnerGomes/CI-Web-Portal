using System.Data;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using CofreInteligente.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace CofreInteligente.Service
{
    public class DepositoService
    {

        private SqliteConnection _connection;

        public DepositoService(){
            _connection = new SqliteConnection("Data Source=C:\\Sqlite\\CI.db");
        }

        public List<Deposito> getDepositos (){
            
            List<Deposito> depositos = new List<Deposito>();

            _connection.Open();

            var command = _connection.CreateCommand();

            command.CommandText =
            @"
                select Id_deposito, id_usuario, Id_lote, dt_deposito 
                from Deposito
                
            ";
            
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {                            
                    Deposito dep = new Deposito();

                    dep.IdLote =  Convert.ToInt32(reader.GetString(0)); 
                    dep.IdUsuario = Convert.ToInt32(reader.GetString(1)); 
                    dep.IdDeposito = Convert.ToInt32(reader.GetString(2));
                    dep.DataDeposito = Convert.ToDateTime(reader.GetString(3), CultureInfo.InvariantCulture);

                    depositos.Add(dep);
                }
            }  

            return depositos;         
        }


        public Deposito getDepositoById (int idDep){

             Deposito dep = new Deposito();

            _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText =
            @"
                select Id_deposito, id_usuario, Id_lote, dt_deposito 
                from Deposito
                WHERE ID_DEPOSITO = $id
                
            ";
            command.Parameters.AddWithValue("$id", idDep); 
            
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {                            
                    dep.IdLote =  Convert.ToInt32(reader.GetString(0)); 
                    dep.IdUsuario = Convert.ToInt32(reader.GetString(1)); 
                    dep.IdDeposito = Convert.ToInt32(reader.GetString(2));
                    dep.DataDeposito = Convert.ToDateTime(reader.GetString(3), CultureInfo.InvariantCulture);
                    
                }
            }  

            return dep;         
        }
        
        public int insertDeposito(Deposito dep){
            try{
            _connection.Open();

            var command = _connection.CreateCommand();

            command.CommandText =
            @"
                insert into  
                Deposito 
                ( id_usuario , id_lote  , Dt_deposito, CD_Status )
                values ( $idUsuario , $idLote, $dataDeposito , 0)              
                
            " ; 
            command.Parameters.AddWithValue("$idLote", dep.IdLote);
            command.Parameters.AddWithValue("$dataDeposito", dep.DataDeposito);
            command.Parameters.AddWithValue("$idUsuario", dep.IdUsuario);

            
            var reader = Convert.ToInt32(command.ExecuteNonQuery());
            
            Console.WriteLine($" INSERIDO: {reader}");
                    
            return reader; 
            }
            catch(Exception e){
                Console.WriteLine($"{e}");
                return 0;
            }            
        }

        public Deposito updateDeposito(Deposito dep){

            _connection.Open();

            var command = _connection.CreateCommand();

            command.CommandText =
            @"
                update  
                Deposito 
                set id_usuario = $idUsuario, id_lote = $idLote , Dt_deposito = $dataDeposito
                where id_deposito = $idDeposito              
                
            " ;
            command.Parameters.AddWithValue("$idDeposito", dep.IdDeposito);  
            command.Parameters.AddWithValue("$idLote", dep.IdLote);
            command.Parameters.AddWithValue("$dataDeposito", dep.DataDeposito);
            command.Parameters.AddWithValue("$idUsuario", dep.IdUsuario);

            var reader = command.ExecuteNonQuery();
            
            Console.WriteLine($" alterado: {reader},{dep.IdDeposito}");
                        
            return getDepositoById(dep.IdDeposito); 
        }

        public int deleteDeposito(int idDep){

            _connection.Open();

            var command = _connection.CreateCommand();

            command.CommandText =
            @"
                delete 
                from Deposito 
                where id_deposito = $id
                
            " ;
            command.Parameters.AddWithValue("$id", idDep);  
            
            var reader = command.ExecuteNonQuery();
            
            Console.WriteLine($" deletado: {reader},{idDep}");
            return reader; 
        }
    }
}