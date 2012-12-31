using System;
using System.Data.Entity;
using System.IO;

namespace FileBasket.Data.v20
{
    public class FileDbContext : DbContext
    {
        static FileDbContext()
        {
            Database.SetInitializer(new FileDbInitializer());
        }

        public FileDbContext() : base("FileDbConnection")
        {
        }

        public DbSet<StoredFile> Files
        {
            get;
            set;
        }

        public DbSet<AttributeValue> AttributeValues
        {
            get;
            set;
        }

        public DbSet<AttributeType> AttributeTypes
        {
            get;
            set;
        }

        public DbSet<Comment> Comments
        {
            get;
            set;
        }

        public DbSet<FileImage> FileImages
        {
            get;
            set;
        }
    }

    public class FileDbInitializer : DropCreateDatabaseIfModelChanges<FileDbContext>
    {
        protected override void Seed(FileDbContext context)
        {
            context.AttributeTypes.Add(new AttributeType {Name = "Genre", Type = "Movie"});
            context.AttributeTypes.Add(new AttributeType {Name = "Slogan", Type = "Movie"});
            context.AttributeTypes.Add(new AttributeType {Name = "Director", Type = "Movie"});
            context.AttributeTypes.Add(new AttributeType {Name = "Cast", Type = "Movie"});
            context.AttributeTypes.Add(new AttributeType {Name = "Country", Type = "Movie"});
            context.AttributeTypes.Add(new AttributeType {Name = "Release Date", Type = "Movie"});
            context.AttributeTypes.Add(new AttributeType {Name = "Codec", Type = "Movie"});


            context.AttributeTypes.Add(new AttributeType {Name = "Composer", Type = "Music"});
            context.AttributeTypes.Add(new AttributeType {Name = "Writer", Type = "Music"});
            context.AttributeTypes.Add(new AttributeType {Name = "Genre", Type = "Music"});
            context.AttributeTypes.Add(new AttributeType {Name = "Codec", Type = "Music"});
            context.AttributeTypes.Add(new AttributeType {Name = "BitRate", Type = "Music"});


            context.AttributeTypes.Add(new AttributeType {Name = "Content", Type = "Media"});
            context.AttributeTypes.Add(new AttributeType {Name = "BitRate", Type = "Media"});
            context.AttributeTypes.Add(new AttributeType {Name = "Codec", Type = "Media"});

            context.AttributeTypes.Add(new AttributeType {Name = "Content", Type = "Other"});


            //Sample Data
            var sampleFile = new StoredFile {Name = "The Hobbit: An Unexpected Journey", FileType = "Movie"};
            sampleFile.AttributeValue.Add(new AttributeValue
                {
                    StoredFile = sampleFile,
                    Value = "Peter Jackson",
                    Type = new AttributeType {Name = "Director", Type = "Movie"}
                });
            sampleFile.AttributeValue.Add(new AttributeValue
                {
                    StoredFile = sampleFile,
                    Value = "USA,New Zeland",
                    Type = new AttributeType {Name = "Country", Type = "Movie"}
                });
            sampleFile.AttributeValue.Add(new AttributeValue
                {
                    StoredFile = sampleFile,
                    Value = "«From the smallest beginnings come the greatest legends.»",
                    Type = new AttributeType {Name = "Slogan", Type = "Movie"}
                });
            sampleFile.AttributeValue.Add(new AttributeValue
                {
                    StoredFile = sampleFile,
                    Value = "180 000 000",
                    Type = new AttributeType {Name = "Budget:", Type = "Movie"}
                });
            sampleFile.FileComments.Add(new Comment
                {
                    CommentText =
                        "This movie was so EPIC i'm speechless. I went with high expectations because Peter Jackson is awesome, but man, they weren't high ENOUGH. I couldn't see any flaw in this movie at all, they do change the way some events happened, but they're details and don't really change the story, actually you can tell they were needed.Jackson also adds some information, but he did say beforehand that he would, and is taken from other Tolkien stories, and as I haven't read them, I was very happy with the change because they were things I didn't know. The way the movie starts is very clever, and the whole introduction before the journey is almost exactly like the book, which I enjoyed very much. The fights scenes, just exactly as LOTR are INCREDIBLE,very well done, and with some funny moments as well. The cast is flawless, I think every actor portrays their character to perfection, I was happy with all the acting choices. The part of the book they picked to end the movie was great, the book though is basically divided into three main events, so it was somewhat predictable, but the scene they made to end the movie was perfect!!. So Basically if you're a Tolkien fan, or just LOTR-Hobbit fan you'll be puking rainbows of epicness throughout the movie.I had the luck to go to the premiere, but i'm obviously gonna go watch it again on IMAX.",
                    StoredFile = sampleFile,
                    User = "GodFather"
                });
            sampleFile.PathOnServer = AppDomain.CurrentDomain.BaseDirectory +
                                      "/App_Data/Samples/Files/Hobbit/SongOfTheLonelyMountain.mp3";

            sampleFile.Image = new FileImage
                {
                    ImageBytes =
                        File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory +
                                          "/App_Data/Samples/Files/Hobbit/Hobbit.jpg")
                };

            context.Files.Add(sampleFile);
            context.SaveChanges();
        }
    }
}