using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;
using Backend.Models.Admin;

namespace Backend.DAL
{
    public class PositionDAL
    {
        public void CreatePosition(Position post)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name",50, post.Name),
            };
            string sql = "INSERT INTO positions(name) VALUES(@name)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdatePosition(Position post)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", post.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name",50, post.Name)
            };
            string sql = "UPDATE positions SET name = @name WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeletePositionById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id),
            };
            string sql = "UPDATE positions SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Position GetPositionById(int id)
        {
            Position position = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id),
            };
            string sql = "SELECT id, name FROM positions WHERE id = @id; SELECT PA.module_id, PA.accessible, PA.writable FROM position_authorizations AS PA, positions AS P WHERE P.id = PA.position_id and P.id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    position = new Position();
                    position.Id = dr.GetInt32(0);
                    position.Name = dr.GetString(1);
                }
                if (position != null)
                {
                    dr.NextResult();
                    position.ModuleAuthorizations = new List<ModuleAuthorization>();
                    while (dr.Read())
                    {
                        ModuleAuthorization ma = new ModuleAuthorization();
                        ma.ModuleId = dr.GetInt32(0);
                        ma.Accessible = dr.GetBoolean(1);
                        ma.Writable = dr.GetBoolean(2);
                        position.ModuleAuthorizations.Add(ma);
                    }
                }
            }
            return position;
        }

        public Position GetPositionByName(string name)
        {
            Position post = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name", 50, name),
            };
            string sql = "SELECT id, name FROM positions WHERE name = @name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    post = new Position();
                    post.Id = dr.GetInt32(0);
                    post.Name = dr.GetString(1);
                }
            }
            return post;
        }

        public List<Position> GetPosition()
        {            
            List<Position> result = new List<Position>();
            string sql = "SELECT id, name FROM positions WHERE is_delete = 0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Position position = new Position();
                    position.Id = dr.GetInt32(0);
                    position.Name = dr.GetString(1);
                    result.Add(position);
                }
            }
            return result;
        }

        public void UpdatePositionAuthorization(int positionId, List<ModuleAuthorization> mas)
        {
            SqlConnection conn = SqlHelper.OpenNewConnection();
            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            //delete
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "DELETE FROM position_authorizations WHERE position_id = " + positionId, null);
            //insert
            foreach (ModuleAuthorization ma in mas)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "INSERT INTO position_authorizations (position_id, module_id, accessible, writable) VALUES ("
                    + positionId + ", " + ma.ModuleId + ", " + (ma.Accessible == true ? 1 : 0) + ", " + (ma.Writable == true ? 1 : 0) + ")", null);
            }
            // commit transcation
            try
            {
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
