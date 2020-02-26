using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PSO2CMXParser
{


    public class CMXparser
    {

		public static List<int> endTagLocations = new List<int>();
		public static byte[] stringFlagByte = new byte[2]{0x2,0x12} ;
		public static byte[] fileByteArray;
        private static bool showDeepLog;
        private static bool showLog;
		
        static CMXparser()
        {   
			showLog = true;
            showDeepLog = false;
        }
		
        public CMXparser(string cmxFile)
        {
			fileByteArray = File.ReadAllBytes(cmxFile);
			string endTag = "vtc0";
			byte[] endTagArray = Encoding.UTF8.GetBytes(endTag);
			BoyerMoore endTagSearcher = new BoyerMoore(endTagArray);
			endTagLocations = endTagSearcher.SearchAll(fileByteArray);
        }
		
        public static void ParseCMX(string cmxFile)
        {
			fileByteArray = File.ReadAllBytes(cmxFile);
			string endTag = "vtc0";
			byte[] endTagArray = Encoding.UTF8.GetBytes(endTag);
			BoyerMoore endTagSearcher = new BoyerMoore(endTagArray);
			endTagLocations = endTagSearcher.SearchAll(fileByteArray);
			
			
			List<byte[]> bodyData = FindDataTag("BODY");
			foreach(byte[] data in bodyData){
				int id = BitConverter.ToInt32(data, 10);
				byte flagByte = data[14];
				//start from 14th bit with text 0x__, 0x01, 0x12 
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				//string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				//string texture4 = Encoding.UTF8.GetString(data, 80, 18);
				//string texture5 = Encoding.UTF8.GetString(data, 101, 18);
				Console.WriteLine("BODY ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("texture file list: {0}, {1}, {2}, {3}, {4}", texture1 , texture2, texture3,texture4, texture5 );
			}
			
			
			List<byte[]> carmData = FindDataTag("CARM");
			foreach(byte[] data in carmData){
				int id = BitConverter.ToInt32(data, 10);
				
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				//string texture4 = Encoding.UTF8.GetString(data, 80, 18);
				//string texture5 = Encoding.UTF8.GetString(data, 101, 18);
				//string texture6 = Encoding.UTF8.GetString(data, 122, 18);
				Console.WriteLine("CARM ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("file list: {0}, {1}, {2}, {3}, {4}, {5}", texture1 , texture2, texture3,texture4, texture5, texture6);
			}
			
			List<byte[]> clegData = FindDataTag("CLEG");
			foreach(byte[] data in clegData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				//string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				//string texture4 = Encoding.UTF8.GetString(data, 80, 18);
				//string texture5 = Encoding.UTF8.GetString(data, 101, 18);
				//string texture6 = Encoding.UTF8.GetString(data, 122, 18);
				Console.WriteLine("CLEG ID " + id);
				Console.WriteLine("texture file list: {0}", texture1 );
				//Console.WriteLine("file list: {0}, {1}, {2}, {3}, {4}, {5}", texture1 , texture2, texture3,texture4, texture5, texture6);
			}
			
			List<byte[]> bdp1Data = FindDataTag("BDP1");
			foreach(byte[] data in bdp1Data){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				//string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				Console.WriteLine("BDP1 ID " + id);
				Console.WriteLine("texture file list: {0}", texture1 );
				//Console.WriteLine("file list: {0}, {1}, {2}", texture1 , texture2, texture3);
			}
			
			List<byte[]> bdp2Data = FindDataTag("BDP2");
			foreach(byte[] data in bdp2Data){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				//string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				Console.WriteLine("BDP2 ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("file list: {0}, {1}, {2}", texture1 , texture2, texture3);
			}
			
			List<byte[]> eyeData = FindDataTag("EYE ");
			foreach(byte[] data in eyeData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				Console.WriteLine("EYE  ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
			}
			
			List<byte[]> eyeblData = FindDataTag("EYEL");
			foreach(byte[] data in eyeblData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				Console.WriteLine("EYEB ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
			}
			
			List<byte[]> eyebData = FindDataTag("EYEB");
			foreach(byte[] data in eyebData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				Console.WriteLine("EYEB ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
			}
			
			List<byte[]> hairData = FindDataTag("HAIR");
			foreach(byte[] data in hairData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				Console.WriteLine("HAIR ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
			}
			
			List<byte[]> bblyData = FindDataTag("BBLY");
			foreach(byte[] data in bblyData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				//string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				//string texture4 = Encoding.UTF8.GetString(data, 80, 18);
				Console.WriteLine("BBLY ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("texture file list: {0}, {1}, {2}, {3}", texture1 , texture2, texture3,texture4);
			}
			
			List<byte[]> faceData = FindDataTag("FACE");
			foreach(byte[] data in faceData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				Console.WriteLine("FACE ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("texture file list: {0}, {1}, {2}, {3}", texture1 , texture2, texture3,texture4);
			}
			
			List<byte[]> fcmnData = FindDataTag("FCMN");
			foreach(byte[] data in fcmnData){
				int id = BitConverter.ToInt32(data, 10);
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				Console.WriteLine("FCMN ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("texture file list: {0}, {1}, {2}, {3}", texture1 , texture2, texture3,texture4);
			}
			
			
			List<byte[]> bclnData = FindDataTag("BCLN");
			foreach(byte[] data in bclnData){
				int id = BitConverter.ToInt32(data, 10);
				Console.WriteLine("BCLN ID " + id);
			}
			
			List<byte[]> iclnData = FindDataTag("ICLN");
			foreach(byte[] data in iclnData){
				int id = BitConverter.ToInt32(data, 10);
				Console.WriteLine("ICLN ID " + id);
			}
			
			
			
			List<byte[]> acceData = FindDataTag("ACCE");
			foreach(byte[] data in acceData){
				
				int id = BitConverter.ToInt32(data, 10);
				//start from 14th bit with text 0x__, 0x01, 0x12 
				string texture1 = Encoding.UTF8.GetString(data, 17, 18);
				//string texture2 = Encoding.UTF8.GetString(data, 38, 18);
				//string texture3 = Encoding.UTF8.GetString(data, 59, 18);
				//string texture4 = Encoding.UTF8.GetString(data, 80, 18);
				//string texture5 = Encoding.UTF8.GetString(data, 101, 18);
				Console.WriteLine("ACCE ID " + id);
				Console.WriteLine("file list: {0}", texture1 );
				//Console.WriteLine("texture file list: {0}, {1}, {2}, {3}, {4}", texture1 , texture2, texture3,texture4, texture5 );
			}
			
			/*
			List<string> tags = new List<string>(){"CARM","CLEG","BDP1","EYEB","BBLY","BCLN","ICLN"};
				
			foreach(var tag in tags){
				FindDataTag(tag);
			}*/

        }
		
        private static List<byte[]> FindDataTag(string tagName)
        {
			List<byte[]> tagData = new List<byte[]>();
			byte[] tagArray = Encoding.UTF8.GetBytes(tagName);
			BoyerMoore tagSearcher = new BoyerMoore(tagArray);
			List<int> tagLocations = tagSearcher.SearchAll(fileByteArray);
				
			foreach (int location in tagLocations)
			{
				//Console.WriteLine(tagName + " Tag Location:" + location);
				int currentEndTaglocation = endTagLocations.FirstOrDefault(v => v > location);
				if(currentEndTaglocation == 0) continue;
				//Console.WriteLine(tagName + " Tag End Location:" + currentEndTaglocation);
				int arrayLength = currentEndTaglocation - location;
				byte[] resultArray = new byte[arrayLength];
				Array.Copy(fileByteArray, location, resultArray, 0, arrayLength);
				//Console.WriteLine("Tag Content: ");
				//Console.WriteLine(Encoding.UTF8.GetString(resultArray));
				tagData.Add(resultArray);
			}
			return tagData;
        }





    }
}

