using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Star Wars - Episode I: The Phantom Menace",
                        ReleaseDate = DateTime.Parse("1999-5-19"),
                        Genre = "Science Fiction",
                        Price = 5.99M,
                        Stock = 12,
                        Director = "George Lucas",
                        Description = "Obi-Wan Kenobi (Ewan McGregor) is a young apprentice Jedi knight under the tutelage of Qui-Gon Jinn (Liam Neeson) ; Anakin Skywalker (Jake Lloyd), who will later father Luke Skywalker and become known as Darth Vader, is just a 9-year-old boy. When the Trade Federation cuts off all routes to the planet Naboo, Qui-Gon and Obi-Wan are assigned to settle the matter.",
                        ImageURL = "https://www.gstatic.com/tv/thumb/v22vodart/23143/p23143_v_v8_ac.jpg"
                    },

                    new Movie
                    {
                        Title = "Star Wars - Episode II: Attack of the Clones",
                        ReleaseDate = DateTime.Parse("2002-5-16"),
                        Genre = "Science Fiction",
                        Price = 5.99M,
                        Stock = 5,
                        Director = "George Lucas",
                        Description = "Set ten years after the events of The Phantom Menace, the Republic continues to be mired in strife and chaos. A separatist movement encompassing hundreds of planets and powerful corporate alliances poses new threats to the galaxy that even the Jedi cannot stem. These moves, long planned by an as yet unrevealed and powerful force, lead to the beginning of the Clone Wars -- and the beginning of the end of the Republic.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BMDAzM2M0Y2UtZjRmZi00MzVlLTg4MjEtOTE3NzU5ZDVlMTU5XkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_UY1200_CR81,0,630,1200_AL_.jpg"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 6.99M,
                        Stock = 4,
                        Director = "Ivan Reitman",
                        Description = "After saving New York City from a ghost attack, the Ghostbusters -- a team of spirit exterminators -- is disbanded for demolishing parts of the city during the battle. But when Ghostbuster Peter Venkman (Bill Murray) learns that spirits have taken an interest in his son, the men launch a rogue ghost-chasing mission. The quest quickly goes awry, landing them in court. But when the ghosts turn on the judge, he issues an order allowing the Ghostbusters to get back to work.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BMTQ2NTk4MjE5Ml5BMl5BanBnXkFtZTgwODIwNjYxMTE@._V1_UY1200_CR90,0,630,1200_AL_.jpg"
                    },

                    new Movie
                    {
                        Title = "Garfield: The Movie",
                        ReleaseDate = DateTime.Parse("2004-6-11"),
                        Genre = "Comedy",
                        Price = 3.99M,
                        Stock = 9,
                        Director = "Peter Hewitt",
                        Description = "Based on the popular comic strip, this live-action comedy follows the exploits of Garfield (Bill Murray), the large, lazy and wisecracking cat owned by hapless Jon Arbuckle (Breckin Meyer). Jon's other housemate, Odie, is a dim but sweet dog who frequently annoys Garfield. When the conniving orange feline gets fed up with Odie, he devises a way to get rid of the pooch. However, after Garfield has a change of heart about Odie, he must find a way to get his fellow pet back.",
                        ImageURL = "https://fanart.tv/fanart/movies/8920/movieposter/garfield-53ed0ccc6be59.jpg"
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = DateTime.Parse("1972-6-11"),
                        Genre = "Crime",
                        Price = 5.49M,
                        Stock = 4,
                        Director = "Francis Ford Coppola",
                        Description = "The Godfather is a 1972 American crime film directed by Francis Ford Coppola and produced by Albert S. Ruddy, based on Mario Puzo's best-selling novel of the same name. It stars Marlon Brando and Al Pacino as the leaders of a fictional New York crime family. The story, spanning 1945 to 1955, chronicles the family under the patriarch Vito Corleone (Brando), focusing on the transformation of Michael Corleone (Pacino) from reluctant family outsider to ruthless mafia boss.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        ReleaseDate = DateTime.Parse("1994-5-16"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Stock = 16,
                        Director = "Frank Darabont",
                        Description = "Andy Dufresne (Tim Robbins) is sentenced to two consecutive life terms in prison for the murders of his wife and her lover and is sentenced to a tough prison. However, only Andy knows he didn't commit the crimes. While there, he forms a friendship with Red (Morgan Freeman), experiences brutality of prison life, adapts, helps the warden, etc., all in 19 years.",
                        ImageURL = "https://fesapusewebsite.blob.core.windows.net/fathom/shawshank-poster-7ef0673ed4915039c6318993a54f04c1.jpg"
                    },
                    new Movie
                    {
                        Title = "Schindler's List",
                        ReleaseDate = DateTime.Parse("1993-2-21"),
                        Genre = "Biography",
                        Price = 2.49M,
                        Stock = 6,
                        Director = "Steven Spielberg",
                        Description = "Businessman Oskar Schindler (Liam Neeson) arrives in Krakow in 1939, ready to make his fortune from World War II, which has just started. After joining the Nazi party primarily for political expediency, he staffs his factory with Jewish workers for similarly pragmatic reasons. When the SS begins exterminating Jews in the Krakow ghetto, Schindler arranges to have his workers protected to keep his factory in operation, but soon realizes that in so doing, he is also saving innocent lives.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg"
                    },
                    new Movie
                    {
                        Title = "Raging Bull",
                        ReleaseDate = DateTime.Parse("1980-12-13"),
                        Genre = "Drama",
                        Price = 7.49M,
                        Stock = 3,
                        Director = "Martin Scorsese",
                        Description = "The story of a middleweight boxer as he rises through ranks to earn his first shot at the middleweight crown. He falls in love with a gorgeous girl from the Bronx. The inability to express his feelings enters into the ring and eventually takes over his life. He eventually is sent into a downward spiral that costs him everything.",
                        ImageURL = "https://posteritati.com/posters/000/000/050/465/raging-bull-md-web.jpg"
                    },
                    new Movie
                    {
                        Title = "Casablanca",
                        ReleaseDate = DateTime.Parse("1942-6-14"),
                        Genre = "Drama",
                        Price = 5.49M,
                        Stock = 5,
                        Director = "Michael Curtiz",
                        Description = "Rick Blaine (Humphrey Bogart), who owns a nightclub in Casablanca, discovers his old flame Ilsa (Ingrid Bergman) is in town with her husband, Victor Laszlo (Paul Henreid). Laszlo is a famed rebel, and with Germans on his tail, Ilsa knows Rick can help them get out of the country.",
                        ImageURL = "https://i.pinimg.com/originals/cc/ad/78/ccad786b0f73004bcc063967cd2c31a4.jpg"
                    },
                    new Movie
                    {
                        Title = "Citizen Kane",
                        ReleaseDate = DateTime.Parse("1941-4-18"),
                        Genre = "Drama",
                        Price = 16.99M,
                        Stock = 4,
                        Director = "Orson Welles",
                        Description = "When a reporter is assigned to decipher newspaper magnate Charles Foster Kane's (Orson Welles) dying words, his investigation gradually reveals the fascinating portrait of a complex man who rose from obscurity to staggering heights. Though Kane's friend and colleague Jedediah Leland (Joseph Cotten), and his mistress, Susan Alexander (Dorothy Comingore), shed fragments of light on Kane's life, the reporter fears he may never penetrate the mystery of the elusive man's final word, Rosebud.",
                        ImageURL = "https://images-na.ssl-images-amazon.com/images/I/51vjiQmDvjL.jpg"
                    },
                    new Movie
                    {
                        Title = "Gone with the Wind",
                        ReleaseDate = DateTime.Parse("1939-7-09"),
                        Genre = "Drama",
                        Price = 11.99M,
                        Stock = 7,
                        Director = "Victor Fleming",
                        Description = "Epic Civil War drama focuses on the life of petulant southern belle Scarlett O'Hara (Vivien Leigh). Starting with her idyllic on a sprawling plantation, the film traces her survival through the tragic history of the South during the Civil War and Reconstruction, and her tangled love affairs with Ashley Wilkes (Leslie Howard) and Rhett Butler (Clark Gable).",
                        ImageURL = "https://images.wolfgangsvault.com/m/xlarge/ZZZ060038-PO/gone-with-the-wind-poster-jan-17-1940.webp"
                    },
                    new Movie
                    {
                        Title = "The Wizard of Oz",
                        ReleaseDate = DateTime.Parse("1939-6-13"),
                        Genre = "Adventure",
                        Price = 3.99M,
                        Stock = 3,
                        Director = "Victor Fleming",
                        Description = "When a tornado rips through Kansas, Dorothy (Judy Garland) and her dog, Toto, are whisked away in their house to the magical land of Oz. They follow the Yellow Brick Road toward the Emerald City to meet the Wizard, and en route they meet a Scarecrow (Ray Bolger) that needs a brain, a Tin Man (Jack Haley) missing a heart, and a Cowardly Lion (Bert Lahr) who wants courage. The wizard asks the group to bring him the broom of the Wicked Witch of the West (Margaret Hamilton) to earn his help.",
                        ImageURL = "https://cdn.shopify.com/s/files/1/1416/8662/products/Wizard_of_Oz_1939_r1998_original_film_art_2000x.jpg"
                    },
                    new Movie
                    {
                        Title = "Lawrence of Arabia",
                        ReleaseDate = DateTime.Parse("1962-8-18"),
                        Genre = "Adventure",
                        Price = 8.49M,
                        Stock = 13,
                        Director = "David Lean",
                        Description = "Due to his knowledge of the native Bedouin tribes, British Lieutenant T.E. Lawrence (Peter O'Toole) is sent to Arabia to find Prince Faisal (Alec Guinness) and serve as a liaison between the Arabs and the British in their fight against the Turks. With the aid of native Sherif Ali (Omar Sharif), Lawrence rebels against the orders of his superior officer and strikes out on a daring camel journey across the harsh desert to attack a well-guarded Turkish port.",
                        ImageURL = "https://cdn3.volusion.com/bxqxk.xvupj/v/vspfiles/photos/FORTYBYSIXTY105-2.jpg"
                    },
                    new Movie
                    {
                        Title = "Singin' in the Rain",
                        ReleaseDate = DateTime.Parse("1952-6-25"),
                        Genre = "Comedy",
                        Price = 9.49M,
                        Stock = 11,
                        Director = "Gene Kelly",
                        Description = "When the transition is being made from silent films to `talkies', everyone has trouble adapting. Don and Lina have been cast repeatedly as a romantic couple, but when their latest film is remade into a musical, only Don has the voice for the new singing part. After a lot of practise with a diction coach, Lina still sounds terrible, and Kathy, a bright young aspiring actress, is hired to record over her voice.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BMWUyNjQ5MTAtNDJhYS00MWQ0LTk2ZTAtZmE4MWNlMjMwMzg3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_.jpg"
                    },
                    new Movie
                    {
                        Title = "It's a Wonderful Life",
                        ReleaseDate = DateTime.Parse("1946-3-11"),
                        Genre = "Drama",
                        Price = 5.99M,
                        Stock = 1,
                        Director = "Frank Capra",
                        Description = "George Bailey has so many problems he is thinking about ending it all - and it's Christmas! As the angels discuss George, we see his life in flashback. As George is about to jump from a bridge, he ends up rescuing his guardian angel, Clarence - who then shows George what his town would have looked like if it hadn't been for all his good deeds over the years.",
                        ImageURL = "https://render.fineartamerica.com/images/rendered/default/poster/8/10/break/images-medium-5/its-a-wonderful-life-ayse-deniz.jpg"
                    },
                    new Movie
                    {
                        Title = "Some Like It Hot",
                        ReleaseDate = DateTime.Parse("1959-11-01"),
                        Genre = "Comedy",
                        Price = 3.99M,
                        Stock = 8,
                        Director = "Billy Wilder",
                        Description = "After witnessing a Mafia murder, slick saxophone player Joe (Tony Curtis) and his long-suffering buddy, Jerry (Jack Lemmon), improvise a quick plan to escape from Chicago with their lives. Disguising themselves as women, they join an all-female jazz band and hop a train bound for sunny Florida. While Joe pretends to be a millionaire to win the band's sexy singer, Sugar (Marilyn Monroe), Jerry finds himself pursued by a real millionaire (Joe E. Brown) as things heat up and the mobsters close in.",
                        ImageURL = "https://posteritati.com/posters/000/000/039/052/important-motion-picture-posters-some-like-it-hot-md-web.jpg"
                    },
                    new Movie
                    {
                        Title = "Ben-Hur",
                        ReleaseDate = DateTime.Parse("1959-3-26"),
                        Genre = "Adventure",
                        Price = 7.99M,
                        Stock = 15,
                        Director = "William Wyler",
                        Description = "Epic drama about an aristocratic Jew living in Judaea who incurs the wrath of a childhood friend, now a Roman tribune. Although forced into slavery on a galley and compelled to witness the cruel persecution of his family, he survives, harbouring dreams of vengeance. A battle at sea and a chariot race are among the memorable sequences. The film used 300 sets at Rome's Cinecitta Studios and won a record 11 Oscars.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BNjgxY2JiZDYtZmMwOC00ZmJjLWJmODUtMTNmNWNmYWI5ODkwL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_.jpg"
                    },
                    new Movie
                    {
                        Title = "Amadeus",
                        ReleaseDate = DateTime.Parse("1984-8-10"),
                        Genre = "Biography",
                        Price = 14.99M,
                        Stock = 5,
                        Director = "Miloš Forman",
                        Description = "Wolfgang Amadeus Mozart (Tom Hulce) is a remarkably talented young Viennese composer who unwittingly finds a fierce rival in the disciplined and determined Antonio Salieri (F. Murray Abraham). Resenting Mozart for both his hedonistic lifestyle and his undeniable talent, the highly religious Salieri is gradually consumed by his jealousy and becomes obsessed with Mozart's downfall, leading to a devious scheme that has dire consequences for both men.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BNWJlNzUzNGMtYTAwMS00ZjI2LWFmNWQtODcxNWUxODA5YmU1XkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_.jpg"
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        ReleaseDate = DateTime.Parse("2003-7-18"),
                        Genre = "Adventure",
                        Price = 12.99M,
                        Stock = 6,
                        Director = "Peter Jackson",
                        Description = "The culmination of nearly 10 years' work and conclusion to Peter Jackson's epic trilogy based on the timeless J.R.R. Tolkien classic, 'The Lord of the Rings: The Return of the King' presents the final confrontation between the forces of good and evil fighting for control of the future of Middle-earth. Hobbits Frodo and Sam reach Mordor in their quest to destroy the `one ring', while Aragorn leads the forces of good against Sauron's evil army at the stone city of Minas Tirith.",
                        ImageURL = "https://cdn.shopify.com/s/files/1/1416/8662/products/Lord_of_the_Rings_Return_of_the_King_2003_original_film_art_2000x.jpg"
                    },
                    new Movie
                    {
                        Title = "Gladiator",
                        ReleaseDate = DateTime.Parse("2000-4-05"),
                        Genre = "Action",
                        Price = 3.49M,
                        Stock = 4,
                        Director = "Ridley Scott",
                        Description = "Set in Roman times, the story of a once-powerful general forced to become a common gladiator. The emperor's son is enraged when he is passed over as heir in favour of his father's favourite general. He kills his father and arranges the murder of the general's family, and the general is sold into slavery to be trained as a gladiator - but his subsequent popularity in the arena threatens the throne.",
                        ImageURL = "https://cdn.shopify.com/s/files/1/1416/8662/products/gladiator_2000_teaser_original_film_art_2000x.jpg"
                    },
                    new Movie
                    {
                        Title = "Raiders of the Lost Ark",
                        ReleaseDate = DateTime.Parse("1981-1-03"),
                        Genre = "Action",
                        Price = 5.49M,
                        Stock = 13,
                        Director = "Steven Spielberg",
                        Description = "Epic tale in which an intrepid archaeologist tries to beat a band of Nazis to a unique religious relic which is central to their plans for world domination. Battling against a snake phobia and a vengeful ex-girlfriend, Indiana Jones is in constant peril, making hair's-breadth escapes at every turn in this celebration of the innocent adventure movies of an earlier era.",
                        ImageURL = "https://www.mplsdowntown.com/wp-content/uploads/2018/05/RaidersOfTheLostArk.jpg"
                    },
                    new Movie
                    {
                        Title = "To Kill a Mockingbird",
                        ReleaseDate = DateTime.Parse("1962-3-11"),
                        Genre = "Crime",
                        Price = 8.99M,
                        Stock = 7,
                        Director = "Robert Mulligan",
                        Description = "Scout Finch (Mary Badham), 6,and her older brother, Jem (Phillip Alford), live in sleepy Maycomb, Ala., spending much of their time with their friend Dill (John Megna) and spying on their reclusive and mysterious neighbor, Boo Radley (Robert Duvall). When Atticus (Gregory Peck), their widowed father and a respected lawyer, defends a black man named Tom Robinson (Brock Peters) against fabricated rape charges, the trial and tangent events expose the children to evils of racism and stereotyping.",
                        ImageURL = "https://cdn.shopify.com/s/files/1/0747/3829/products/HP2686_05ed5325-ea25-417d-a506-af004dcf551e_1024x1024.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}