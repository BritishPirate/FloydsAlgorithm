using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

//C:\Users\Dell\Documents\Floyds CSV Files\comp111cities.csv
//C:\Users\Dell\Documents\Floyds CSV Files\comp111citiestitles.csv
namespace Floyds
{
    public partial class FloydsWinForm : Form
    {
        public List<List<float?>> distMatrix = new List<List<float?>>();
        public List<List<float>> routeMatrix = new List<List<float>>();
        public List<List<List<float?>>> distMatrixHistory = new List<List<List<float?>>>();
        public List<List<List<float>>> routeMatrixHistory = new List<List<List<float>>>();
        public List<string> headers = new List<string>();
        public string startupPath = Application.StartupPath;
        public bool runFloydsClicked = false;

        public FloydsWinForm()
        {
            InitializeComponent();
        }

        private void RunFloyds_Click(object sender, EventArgs e)
        {
            runFloydsClicked = true;
            int i = 0;
            int iy = 0;
            int ix = 0;
            distMatrix.Clear();
            distMatrixHistory.Clear();
            routeMatrix.Clear();
            routeMatrixHistory.Clear();
            headers.Clear();

            #region Comment
            /*List<string> tempReg = new List<string>();
            string ugly = File.ReadAllText("C:\\Users\\Dell\\Documents\\Floyds.txt").Trim();
            Regex newLine = new Regex(@"((?:(?:\d?s?)\,?)*)\;?");
            Regex newElement = new Regex(@"\d+|s");
            MatchCollection lists = newLine.Matches(ugly);
	
            foreach(Match match in lists)
            {
                GroupCollection groups = match.Groups;
                distMatrix.Add(new List<float?>());
                var tempReg = newElement.Matches(groups[1].ToString());
                foreach (Match match2 in tempReg)
                {
                    distMatrix[i].Add(float.Parse(match2.ToString()));
                }
                i += 1;
                //tempReg.Add(groups[1].ToString());
            }
            */
            #endregion

            string filepath = string.Empty;
            
            if(FileAddressBox.Text == "")
            {
                filepath = Application.StartupPath + @"\InitialTable.csv";
            }
            else
            {
                filepath = FileAddressBox.Text;
            }

            using (var reader = new StreamReader(filepath))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                iy = 0;
                while (!reader.EndOfStream)
                {
                    ix = 0;
                    float u = 0;
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    bool isNumber = float.TryParse(values[0], out u);
                    if(IncludeTitles.Checked == false && values[0] != "n" && isNumber == false)
                    {
                        IncludeTitles.Checked = true;
                    }
                    if (IncludeTitles.Checked == true)
                    {
                        if (iy == 0)
                        {
                            ix = 0;
                            foreach (var value in values)
                            {
                                if (ix != 0)
                                {
                                    headers.Add(value);
                                }
                                ix += 1;
                            }
                        }
                        else
                        {
                            distMatrix.Add(new List<float?> { });
                            foreach (var value in values)
                            {
                                if (value == "n")
                                {
                                    distMatrix[iy - 1].Add(null);
                                }

                                else if (ix == 0)
                                {

                                }

                                else 
                                {
                                    distMatrix[iy - 1].Add(float.Parse(value));
                                }
                                ix += 1;
                            }
                        }
                    }
                    else
                    {
                        distMatrix.Add(new List<float?> { });
                        foreach (var value in values)
                        {
                                if (value == "n")
                                {
                                    distMatrix[iy].Add(null);
                                }

                                else
                                {
                                    distMatrix[iy].Add(float.Parse(value));
                                }
                            ix += 1;
                        }
                    }
                    iy += 1;
                }
            }
            i = 0;
            if (IncludeTitles.Checked == false)
            {
                foreach(var elem in distMatrix)
                {
                    headers.Add(Convert.ToString(i));
                    i += 1;
                }
            }
            i = 0;
            ix = 0;
            iy = 0;
            while (iy < distMatrix.Count)
            {
                routeMatrix.Add(new List<float> { });
                while (ix < distMatrix.Count)
                {
                    routeMatrix[iy].Add((ix + 1));
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }

            distMatrixHistory.Add( dupeDistMatrix (distMatrix) );  
            routeMatrixHistory.Add( dupeRouteMatrix (routeMatrix) );

            Console.WriteLine("Initial Route Matrix");

            MatrixTable.ColumnCount = (routeMatrix.Count());
            /*
            foreach (List<float> Sublist in routeMatrix)
            {
                MatrixTable.Rows.Add();
            }
            */
            
            i = 0;
            Console.WriteLine("Initial Distance Table");
            Console.WriteLine();

            List<List<float?>> temp = new List<List<float?>>();
            ix = 0;
            iy = 0;
            while (iy < distMatrix.Count)
            {
                temp.Add(new List<float?> {1});
                while (ix < (distMatrix.Count - 1))
                {
                    temp[iy].Add(1);
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }

            ix = 0;
            iy = 0;
            while (iy < temp.Count)
            {
                while (ix < temp.Count)
                {
                    temp[iy][ix] = distMatrix[iy][ix];
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }

            var matrixOfChanges = Changed(temp, distMatrix);

            while (i < distMatrix.Count)
            {
                Console.WriteLine("Iteration number " + (i));
                Console.WriteLine();
                Console.WriteLine("Distance Matrix");

                ix = 0;
                iy = 0;
                while (iy < temp.Count)
                {
                    while (ix < temp.Count)
                    {
                        temp[iy][ix] = distMatrix[iy][ix];
                        ix += 1;
                    }
                    ix = 0;
                    iy += 1;
                }

                distMatrix = DistIteration(distMatrix, i);
                matrixOfChanges = Changed(temp, distMatrix);
                routeMatrix = RouteIteration(routeMatrix, matrixOfChanges, i);

                distMatrixHistory.Add( dupeDistMatrix (distMatrix));
                routeMatrixHistory.Add( dupeRouteMatrix (routeMatrix) );
                i += 1;
            }

            //distMatrix[0][0] = distMatrix[0][0] + 1;
            i = 0;
            ix = 0;
            iy = 0;
            #region
            /*
            while (i == 0)
            {
                RouteAToBinterface(distMatrix, routeMatrix);
                Console.WriteLine();
                Console.WriteLine("----------------------");
            }
            */
            #endregion

            Steps.Text = "Steps: " + distMatrixHistory.Count();

        }

        public List<List<float?>> DistIteration(List<List<float?>> inputList, int iteNum)
        {
            int ix = 0;
            int iy = 0;
            while (iy < inputList.Count)
            {
                while (ix < inputList.Count)
                {
                    if ((inputList[iy][iteNum] != null & inputList[iteNum][ix] != null) && (inputList[iy][ix] == null | inputList[iy][ix] > inputList[iy][iteNum] + inputList[iteNum][ix]))
                    {
                        inputList[iy][ix] = inputList[iy][iteNum] + inputList[iteNum][ix];
                    }
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }
            return inputList;
        }

        public List<List<float>> RouteIteration(List<List<float>> inputMatrix, List<List<float>> changedValues, int iteNum)
        {
            int ix = 0;
            int iy = 0;

            List<List<float>> outputMatrix = new List<List<float>>();
            outputMatrix = inputMatrix;
            while (iy < inputMatrix.Count)
            {
                while (ix < inputMatrix.Count)
                {
                    if (changedValues[iy][ix] == 1)
                    {
                        outputMatrix[iy][ix] = inputMatrix[iy][iteNum];
                    }
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }
            return outputMatrix;
        }

        public List<List<float>> Changed(List<List<float?>> oldDistMatrix, List<List<float?>> newDistMatrix)
        {
            int ix = 0;
            int iy = 0;
            List<List<float>> matrixOfChanges = new List<List<float>>();
            while (iy < oldDistMatrix.Count)
            {
                matrixOfChanges.Add(new List<float> { });
                while (ix < oldDistMatrix.Count)
                {
                    matrixOfChanges[iy].Add(ix);
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }

            iy = 0;
            ix = 0;
            while (iy < oldDistMatrix.Count)
            {
                while (ix < oldDistMatrix.Count)
                {
                    if (oldDistMatrix[iy][ix] == newDistMatrix[iy][ix])
                    {
                        matrixOfChanges[iy][ix] = 0;
                    }
                    else
                    {
                        matrixOfChanges[iy][ix] = 1;
                    }
                    ix += 1;
                }
                ix = 0;
                iy += 1;
            }
            return matrixOfChanges;
        }

        public List<string> RouteAToB(int a, int b, List<List<float>> routeMatrix)
        {
            List<string> routeList = new List<string>();
            float temp = 0;
            temp = a;
            while (temp != b)
            {
                routeList.Add(headers[Convert.ToInt32(routeMatrix[Convert.ToInt32(temp-1)][b-1] - 1)]);
                temp = routeMatrix[Convert.ToInt32(temp-1)][b-1];
            }


            return routeList;
        }

        public void RouteAToBinterface(List<List<float?>> distMatrix, List<List<float>> routeMatrix)
        {
            int i = 0;
            int a = Convert.ToInt32(FromBox.Text);
            int b = Convert.ToInt32(ToBox.Text);
            CostTitle.Text = "Cost: " + distMatrix[a - 1][b - 1].ToString();
            List<string> routeList = new List<string>();
            routeList = RouteAToB(a, b, routeMatrix);
            string route = a + " -> ";
            i = 0;
            while (i < (routeList.Count - 1))
            {
                route = route + headers[Convert.ToInt32(routeList[i])] + " -> ";
                i += 1;
            }
            route = route + routeList[i];
            RouteTitle.Text = "Route:" + route;
        }

        private void FindRoute_Click(object sender, EventArgs e)
        {
            if (!runFloydsClicked || FromBox.Text == string.Empty || ToBox.Text == String.Empty )
            {
                return;
            }
            int i = 0;
            int a = Convert.ToInt32(elemPositionTitles(0, FromBox.Text)) + 1;
            int b = Convert.ToInt32(elemPositionTitles(0, ToBox.Text)) + 1;
            CostTitle.Text = "Cost: " + distMatrix[a][b].ToString();
            List<string> routeList = new List<string>();
            routeList = RouteAToB(a, b, routeMatrix);
            string route = headers[a] + " -> ";
            i = 0;
            while (i < (routeList.Count - 1))
            {
                route = route + routeList[i] + " -> ";
                i += 1;
            }
            route = route + routeList[i];
            RouteTitle.Text = "Route: " + route;
        }


        public bool goToMatrixClicked = false;


        //C:\Users\Dell\Documents\Floyds CSV Files\comp111cities.csv
        private void GoToMatrix_Click(object sender, EventArgs e)
        {
            if (!runFloydsClicked)
            {
                return;
            }
            if (RouteOrDistance.SelectedIndex != 0 && RouteOrDistance.SelectedIndex != 1)
            {
                RouteOrDistance.SelectedIndex = 0;
            }
            if(StepNumberBox.Text == "")
            {
                StepNumberBox.Text = "1";
            }
            int matrixNum = Convert.ToInt32(StepNumberBox.Text) - 1;
            int i = 0;

            if (matrixNum > distMatrixHistory.Count)
            {

            }

            else
            {
                if (goToMatrixClicked == true)
                {
                }
                /*
                foreach (var row in MatrixTable.Rows)
                {
                    MatrixTable.Rows.RemoveAt(0);
                }
                */
                MatrixTable.Rows.Clear();
                
                if (IncludeTitles.Checked == true)
                {
                    
                }
                i = 0;
                if (RouteOrDistance.SelectedIndex == 0)
                {
                    foreach (List<float?> list in distMatrixHistory[matrixNum])
                    {
                        MatrixTable.Rows.Add(mapToStringNull(list, i));
                        i += 1;
                    }
                }
                else
                {
                    foreach (List<float> list in routeMatrixHistory[matrixNum])
                    {
                        MatrixTable.Rows.Add(mapToString(list, i));
                        i += 1;
                    }
                }
                i = 0;

                if(IncludeTitles.Checked == true)
                {
                    foreach(DataGridViewRow row in MatrixTable.Rows)
                    {
                        if (i != headers.Count)
                        {
                            row.HeaderCell.Value = headers[i];
                        }
                        i += 1;
                        
                    }
                    i = 0;
                    foreach (string elem in headers)
                    {
                        MatrixTable.Columns[i].HeaderCell.Value = elem;
                        i += 1;
                    }
                }
                else
                {
                    foreach(DataGridViewRow row in MatrixTable.Rows)
                    {
                        row.HeaderCell.Value = i.ToString();
                        i += 1;
                    }
                    i = 0;
                    foreach (DataGridViewColumn col in MatrixTable.Columns)
                    {
                        MatrixTable.Columns[i].HeaderCell.Value = i.ToString();
                        i += 1;
                    }
                }

                /*
                for (int index = 1; index < (distMatrix[0].Count); index++)
                {
                    MatrixTable.Columns[index].Name = (index).ToString();
                }
                */
                goToMatrixClicked = true;
            }
        }

        string[] mapToString(List<float> a, int b)
        {
            string[] temp = new string[a.Count];
            int i = 0;
            foreach (float elem in a)
            {
                if (IncludeTitles.Checked)
                {
                    temp[i] = headers[Convert.ToInt32(elem - 1)];
                }
                else
                {
                    temp[i] = elem.ToString();
                }
                i += 1;
            }
            return temp;
        }

        string[] mapToStringNull(List<float?> a, int b)
        {
            string[] temp = new string[a.Count];
            int i = 0;
            //temp[0] = b.ToString();
            foreach (float? elem in a)
            {
                if (elem == null)
                {
                    temp[i] = "N/A";
                }
                else
                {
                    temp[i] = elem.ToString();
                }
                i += 1;
            }
            return temp;
        }

        public List<List<float?>> dupeDistMatrix(List<List<float?>> distMatrix)
        {
            int ix = 0;
            int iy = 0;
            List<List<float?>> temp = new List<List<float?>>();
            foreach(List<float?> list in distMatrix)
            {
                ix = 0;
                temp.Add(new List<float?>());
                foreach(int? elem in list)
                {
                    temp[iy].Add(distMatrix[iy][ix]);
                    ix += 1;
                }
                iy += 1;
            }
            return temp;
        }

        public List<List<float>> dupeRouteMatrix(List<List<float>> routeMatrix)
        {
            int ix = 0;
            int iy = 0;
            List<List<float>> temp = new List<List<float>>();
            foreach (List<float> list in routeMatrix)
            {
                ix = 0;
                temp.Add(new List<float>());
                foreach (int? elem in list)
                {
                    temp[iy].Add(routeMatrix[iy][ix]);
                    ix += 1;
                }
                iy += 1;
            }
            return temp;
        }

        public int? elemPositionTitles(int i, string elem)
        {
            if(i < headers.Count)
            {
                if(elem == headers[i])
                {
                    return 0;
                }
                else
                {
                    return (1 + elemPositionTitles((i + 1), elem));
                }
            }
            else
            {
                return null;
            }
        }
        private void FloydsWinForm_Load(object sender, EventArgs e)
        {
            
        }

        private void IncludeTitles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RouteOrDistance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MatrixTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FindFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    FileAddressBox.Text = filePath;
                }
            }
        }
    }

    static class Extensions
    {
        static List<List<T>> Copy<T>(this List<List<T>> list)
        {
            return list.Select(l => new List<T>(l)).ToList();
        }
    }
}
