using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PoemGenerator.Models
{
    public class WordContext: DbContext
    {
        public WordContext() : base("Data Source=./;Initial Catalog=Worddb;Integrated Security=True")
        { }

        public DbSet<Noun> Nouns{ get; set; }
        public DbSet<Verb> Verbs { get; set; }
        public DbSet<Adjective> Adjectives { get; set; }
        public DbSet<Adverb> Adverbs { get; set; }

        public DbSet<Pronoun> Pronouns { get; set; }

    }
}