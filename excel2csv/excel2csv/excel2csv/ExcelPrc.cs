using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;


namespace excel2csv
{
    class ExcelPrc
    {
        private static readonly int skipRows;
        private static readonly int skipCols;

        public static string[] ReadExcelDat(string file_path)
        {
           return  ReadExcelData(file_path);
        }

        private static string[] ReadExcelData(string file_path)
        {
            List<string> lines = new List<string>();
            var file = new FileInfo(file_path);
            using (FileStream fs = file.Open(FileMode.Open))
            {

                IExcelDataReader reader;

                if (file.Extension.Equals(".xls"))
                {
                    reader = ExcelDataReader.ExcelReaderFactory.CreateBinaryReader(fs);
                }
                else
                    if (file.Extension.Equals(".xlsx"))
                {
                    reader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(fs);
                }
                else
                {
                    throw new Exception("対応していない拡張子");
                }

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = false
                    }
                };

                var dataSet = reader.AsDataSet(conf);
                var dataTable = dataSet.Tables[0];

                int rowsLen = dataTable.Rows.Count;
                int colsLen = dataTable.Columns.Count;

                for (int row = 0; row < rowsLen; row++)
                {
                    if ((row < skipRows))
                    {
                        continue;
                    }
                    List<string> line = new List<string>();
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    for (int col = 0; col < colsLen; col++)
                    {
                        if ((col < skipCols))
                        {
                            continue;
                        }
                        var data = dataTable.Rows[row][col];
                        line.Add(data.ToString());
                    }
                    string lineStr = string.Join(",", line.ToArray());
                    lines.Add(lineStr);
                }
                string[] linesArray = lines.ToArray();

                fs.Close();
                return linesArray;
            }
        }
    }
}
