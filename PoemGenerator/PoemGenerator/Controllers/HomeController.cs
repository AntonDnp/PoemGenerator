using PoemGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoemGenerator.Controllers
{
    public class HomeController : Controller
    {
        WordContext wc = new WordContext();
        Random rnd = new Random();

         // GET: Home
        public ActionResult Index()
        {


            //WordContext wc = new WordContext();
            // Здесь используется хелпер SelectList, который создает последовательность объектов SelectListItem

            // wc.Nouns - коллекция которая передается в в список
            // "Full_Word"  - те значения, которые отправляются на сервер
            // "First" - те значения котрые отображаются в списке для выбора пользователем

           
            
            
            //SelectList words = new SelectList(wc.Pronouns, "Full_Word", "Full_Word");
            SelectList words = new SelectList(wc.Nouns, "Full_Word", "Full_Word");
            ViewBag.Words = words;

            SelectList words1 = new SelectList(wc.Nouns, "Full_Word", "Full_Word");
            ViewBag.Words1 = words1;



            return View("Index");
        }

        
        [HttpPost]
        public ActionResult Create(List<string> Select)
        {
            //WordContext wc = new WordContext();

            List<string> one = new List<string>();
            List<string> two = new List<string>();
            List<string> three = new List<string>();
            List<string> four = new List<string>();

            

           

            var verb = wc.Verbs.ToArray();
            var pronoun = wc.Pronouns.ToArray();
            var noun = wc.Nouns.ToArray();
            var adjective = wc.Adjectives.ToArray();
            var adverb = wc.Adverbs.ToArray();


            one.Add(Select[0]);
            two.Add(Select[1]);
            three.Add(Rifma(Select[0]));
            four.Add(Rifma(Select[1]));

            one.Insert(0, verb[rnd.Next(0, verb.Length)].Full_Word);
            two.Insert(0, verb[rnd.Next(0, verb.Length)].Full_Word);
            three.Insert(0, verb[rnd.Next(0, verb.Length)].Full_Word);
            four.Insert(0, verb[rnd.Next(0, verb.Length)].Full_Word);


            one.Insert(0, pronoun[rnd.Next(0, pronoun.Length)].Full_Word);
            two.Insert(0, noun[rnd.Next(0, noun.Length)].Full_Word);
            three.Insert(0, adjective[rnd.Next(0, adjective.Length)].Full_Word);
            four.Insert(0, adverb[rnd.Next(0, adverb.Length)].Full_Word);

            ViewBag.Words2 = one;
            ViewBag.Words3 = two;
            ViewBag.Words4 = three;
            ViewBag.Words5 = four;

            return View();
        }

        public string Rifma(string slovo)
        {
            //WordContext wc = new WordContext();

            string tmp=null;
             string tmp1=null;
             List<string> rifma = new List<string>();

              foreach(var item in wc.Nouns)
              {
                 if (item.Full_Word == slovo)
                 {
                    tmp = item.First;
                    tmp1 = item.Full_Word;
                    break;
                 }
              }
          



             foreach (var item in wc.Nouns)
             { 
                  if (slovo == item.Full_Word)
                    continue;
                 
                
                  if (tmp.Length == item.First.Length & tmp.Length == 2)
                  {


                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[0] == item.First[0]))
                    {
                        rifma.Add(item.Full_Word);
                        

                    }

                  }
                
 
                 else if (tmp.Length == item.First.Length & tmp.Length == 3)
                 {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2]) | (tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[1] == item.First[1] & tmp[2] == item.First[2]))
                    {
                        
                        rifma.Add(item.Full_Word);
                    }
                 }

                else if (tmp.Length == item.First.Length & tmp.Length == 4)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]) | (tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]) | (tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2]) | (tmp[2] == item.First[2] & tmp[3] == item.First[3]))
                    {
                        //Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length == item.First.Length & tmp.Length == 5)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3] & tmp[4] == item.First[4]) | (tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3] & tmp[4] == item.First[4]) | (tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]) | (tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]))
                    {
                        // Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }


                else if (tmp.Length > item.First.Length & tmp.Length == 3 & tmp.Length == 2)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[1] == item.First[0] & tmp[2] == item.First[1]))
                    {
                        //Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length > item.First.Length & tmp.Length == 4 & item.First.Length == 2)
                {
                    if ((tmp[2] == item.First[0] & tmp[3] == item.First[1]) | (tmp[0] == item.First[0] & tmp[1] == item.First[1]))
                    {
                        
                        rifma.Add(item.Full_Word);
                    }
                }
               
              else if (tmp.Length > item.First.Length & tmp.Length == 4 & item.First.Length == 3)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2]) | (tmp[1] == item.First[0] & tmp[2] == item.First[1] & tmp[3] == item.First[2]) | (tmp[2] == item.First[1] & tmp[3] == item.First[2]))
                    {
                       
                        rifma.Add(item.Full_Word);
                    }
                }
               
              
              else if (tmp.Length > item.First.Length & tmp.Length == 5 & item.First.Length == 2)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[3] == item.First[0] & tmp[4] == item.First[1]))
                    {
                        
                        rifma.Add(item.Full_Word);
                    }
                }

             
              else if (tmp.Length > item.First.Length & tmp.Length == 5 & item.First.Length == 3)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2]) | (tmp[2] == item.First[0] & tmp[3] == item.First[1] & tmp[4] == item.First[2]))
                    {
                       
                        rifma.Add(item.Full_Word);
                    }
                }

               else if (tmp.Length > item.First.Length & tmp.Length == 5 & item.First.Length == 4)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]) | (tmp[2] == item.First[1] & tmp[3] == item.First[2] & tmp[4] == item.First[3]))
                    {
                       
                        rifma.Add(item.Full_Word);
                    }
                }


                else if (tmp.Length > item.First.Length & tmp.Length == 6 & item.First.Length == 5)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]) | (tmp[2] == item.First[1] & tmp[3] == item.First[2] & tmp[4] == item.First[3]))
                    {
                        // Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                // Слог из базы больше введенного


                else if (tmp.Length < item.First.Length & tmp.Length == 2 & item.First.Length == 3)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[0] == item.First[1] & tmp[1] == item.First[2]))
                    {
                       
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length < item.First.Length & tmp.Length == 2 & item.First.Length == 4)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[0] == item.First[2] & tmp[1] == item.First[3]))
                    {
                        // Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length < item.First.Length & tmp.Length == 3 & item.First.Length == 4)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2]) | (tmp[1] == item.First[2] & tmp[2] == item.First[3]) | (tmp[0] == item.First[1] & tmp[1] == item.First[2] & tmp[2] == item.First[3]))
                    {
                        //Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length < item.First.Length & tmp.Length == 2 & item.First.Length == 5)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1]) | (tmp[0] == item.First[3] & tmp[1] == item.First[4]))
                    {
                        // Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length < item.First.Length & tmp.Length == 3 & item.First.Length == 5)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2]) | (tmp[0] == item.First[2] & tmp[1] == item.First[3] & tmp[2] == item.First[4]))
                    {
                        // Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else if (tmp.Length < item.First.Length & tmp.Length == 4 & item.First.Length == 5)
                {
                    if ((tmp[0] == item.First[0] & tmp[1] == item.First[1] & tmp[2] == item.First[2] & tmp[3] == item.First[3]) | (tmp[1] == item.First[2] & tmp[2] == item.First[3] & tmp[3] == item.First[4]))
                    {
                        //Console.WriteLine(word.full_word);
                        rifma.Add(item.Full_Word);
                    }
                }

                else continue;


            }

            if (rifma.Count() > 0)
                return rifma[rnd.Next(0, rifma.Count())];

            else return "Рифма не найдена";

         
            
        }
        
        
    }
}