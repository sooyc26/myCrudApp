﻿using myCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace myCrudApp.Services
{
    public class LyricService
    {
        readonly string connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public int Create(LyricsCreateRequest request)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Lyrics_Insert";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Lyrics", request.Lyrics);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return id;
        }

        public List<Lyrics> ReadAll()
        {
            var lyrics = new List<Lyrics>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Lyrics_SelectAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lyric = new Lyrics()
                        {
                            Id = (int)reader["Id"],
                            Lyric = (string)reader["Lyrics"]
                        };
                        lyrics.Add(lyric);

                        reader.Close();
                    }
                    conn.Close();

                }
            }
            return lyrics;
        }

        public Lyrics ReadById(int id)
        {
            var lyrics = new Lyrics();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Lyrics_SelectAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lyric = new Lyrics()
                        {
                            Id = (int)reader["Id"],
                            Lyric = (string)reader["Lyrics"]
                        };
                        lyrics = lyric;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return lyrics;
        }

        public int Update(LyricsUpdateRequest request, int id)
        {
            int retId = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Lyrics_Update";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Lyrics", request.Lyrics);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return retId;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Lyrics_Delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Close();
            }
        }
    }
}