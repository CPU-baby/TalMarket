using System;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;
using UnityEngine.Networking;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBConnection : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(DBCreate());
    }
    IEnumerator DBCreate()
    {
        string filePath = string.Empty;
        filePath = Application.dataPath + "/ranking.db";
        if (!File.Exists(filePath))
        {
            File.Copy(Application.streamingAssetsPath + "/ranking.db", filePath);
        } 
        Debug.Log("DB 생성 완료");
        yield return null;
    }

    public string GetDBFilePath()
    {
        string str = string.Empty;
        str = "URI=file:" + Application.dataPath + "/ranking.db";
        return str;
    }

    // Start is called before the first frame update
    void Start()
    {
        DBConnectionCheck();
        //insertPlayer();
        //readRanking();
        //updateScore("원예린");
        //readRanking();
    }
    public void DBConnectionCheck()
    {
        try
        {
            IDbConnection dbConn = new SqliteConnection(GetDBFilePath());
            dbConn.Open();

            if (dbConn.State == ConnectionState.Open)
            {
                Debug.Log("DB연결 성공");
            }
            else
            {
                Debug.Log("DB연결 실패");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void insertPlayer()
    {
        string name = "원예린";
        string belonging = "3412";

        IDbConnection dbConn = new SqliteConnection(GetDBFilePath());
        dbConn.Open();
        
        string sql = "insert into TalRanking (num, name, belong) values (0, '" + name + "', '" + belonging + "')";
        IDbCommand dbCommand = dbConn.CreateCommand();
        dbCommand.CommandText = sql;
        IDataReader dataReader = dbCommand.ExecuteReader();

        dataReader.Dispose();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Dispose();
        dbConn = null;
    }


    public void updateScore(string name)
    {
        int score = 3000;

        IDbConnection dbConn = new SqliteConnection(GetDBFilePath());
        dbConn.Open();

        string sql = "update TalRanking set score = " + score + " where name = '" + name + "'";
        IDbCommand dbCommand = dbConn.CreateCommand();
        dbCommand.CommandText = sql;
        IDataReader dataReader = dbCommand.ExecuteReader();

        dataReader.Dispose();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Dispose();
        dbConn = null;
    }

    public void readRanking()
    {
        IDbConnection dbConn = new SqliteConnection(GetDBFilePath());
        dbConn.Open();

        string sql = "Select * from TalRanking limit 10";
        IDbCommand dbCommand = dbConn.CreateCommand();
        dbCommand.CommandText = sql;
        IDataReader dataReader = dbCommand.ExecuteReader();

        while (dataReader.Read())
        {
            Debug.Log(dataReader.GetInt32(0) + "번째, " + dataReader.GetString(1) + "님의 소속은 " + dataReader.GetString(2) + ", 점수는 " + dataReader.GetInt32(3) + "입니다.");
        }

        dataReader.Dispose();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Dispose();
        dbConn = null;
    }
}
