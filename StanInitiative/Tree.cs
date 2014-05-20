using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StanInitiative
{
    public class Tree
    {
        Paths shp = new Paths();
        //Funk shf = new Funk();
        public string[] alllines;
        public Node nodegen;
        public class Node
        {
            private string namecom;//название команды
            private List<string> namemas;//всевозможные варианты названий команд
            private string idcom;//идентификатор команды
            private List<Node> mascom;//ветви подкоманд
            public Node nodeup;//родитель команды
            public bool numb;//проверка на использование чисел
            public int numbf;//нижний порог чисел
            public int numbl;//верхний порог чисел
            //конструктор для команды без использования чисел
            public Node(List<string> str, string ids, Node nd)
            {
                this.namemas = str;
                this.namecom = str[0];
                this.idcom = ids;
                this.mascom = new List<Node>();
                this.nodeup = nd;
            }
            //конструктор для команды с использованием чисел
            public Node(List<string> str, string ids, Node nd, int nf, int nl)
            {
                this.namemas = str;
                this.namecom = str[0];
                this.idcom = ids;
                this.mascom = new List<Node>();
                this.nodeup = nd;
                this.numb = true;
                this.numbf = nf;
                this.numbl = nl;
            }
            //конструктор для корня
            public Node(string str, string ids, Node nd, bool nb)
            {
                this.namemas = new List<string>();
                this.namecom = str;
                this.idcom = ids;
                this.mascom = new List<Node>();
                this.nodeup = nd;
                this.numb = nb;
            }
            //добавить подкоманду
            public void addnode(Node nd)
            {
                this.mascom.Add(nd);
            }
            //изменить название команды
            public void setname(string str)
            {
                this.namecom = str;
            }
            //получить подкоманду
            public Node getnode(int n)
            {
                return this.mascom[n];
            }
            //получить родителя
            public Node getreturn()
            {
                return this.nodeup;
            }
            //получить число подкоманд
            public int getlen()
            {
                return this.mascom.Count;
            }
            //получить название команды
            public string getname()
            {
                return this.namecom;
            }
            //получить идентификатор команды
            public string getid()
            {
                return this.idcom;
            }
            //получить нижний порог чисел
            public int getf()
            {
                return this.numbf;
            }
            //получить верхний порог чисел
            public int getl()
            {
                return this.numbl;
            }
            //получить List названий команды
            public List<string> getnmas()
            {
                return this.namemas;
            }
            //найти команду по названию
            public int findcom(string str)
            {
                for (int i = 0; i < this.getlen(); i++)
                {
                    for (int j = 0; j < mascom[i].getnmas().Count; j++)
                    {
                        if (str.IndexOf(mascom[i].getnmas()[j]) > -1)
                        {
                            mascom[i].setname(mascom[i].getnmas()[j]);
                            return i;
                        }
                    }
                }
                return -1;
            }
        }
        //конструктор
        public Tree()
        {
            //считать из файла все строки в string[]
            alllines = System.IO.File.
                ReadAllLines(shp.genPATH + "Command.txt", Encoding.GetEncoding(1251));
            this.nodegen = new Node("general", null, null, false);//создать корень
            Node nodetest = this.nodegen;//редактируемая команда
            int ind = 1;//индекс глубины дерева
            for(int i=0;i<alllines.Length;i++)//обработка строк файла
            {
                string[] nm=alllines[i].Split('\t');//разбиваем строку на подстроки
                int kol = nm[0].Split('-').Length;//вычисляем глубину дерева для данной команды
                    //если индекс меньше предыдущего значит нужно вернуться к родителю
                    if (kol < ind)
                    {
                        //возвращаемся на уровень выше пока не попадём на нужный уровень
                        while (ind != kol)
                        {
                            nodetest = nodetest.getreturn();
                            ind--;
                        }
                    }
                    //если индекс больше предыдущего значит нужно перейти к последней подкоманде
                    if (kol > ind)
                    {
                        nodetest = nodetest.getnode(nodetest.getlen() - 1);
                        ind = kol;
                    }
                    //создаём List названий команды
                    List<string> mas= new List<string>();
                    int nml = nm.Length;
                    bool fl = false;
                    if (nml>2&&nm[nml - 2].Equals("!"))
                    {
                        nml--;
                        fl = true;
                    }
                    for (int j = 1; j < nml; j++)
                        mas.Add(nm[j]);
                    if (fl)
                        nodetest.addnode(new Node(mas, nm[0], nodetest,
                        Convert.ToInt32(nm[nm.Length-1].Split('-')[0]),
                        Convert.ToInt32(nm[nm.Length-1].Split('-')[1])));
                    else
                        nodetest.addnode(new Node(mas, nm[0], nodetest));
            }
            while (nodetest.getreturn() != null)//возвращаемся в корень
            {
                nodetest = nodetest.getreturn();
            }
            this.nodegen = nodetest;
        }
    }
}
