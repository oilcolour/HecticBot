using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] reactionMemes;

        string[] roastSomeone;

        public MyBot()
        {
            rand = new Random();

            reactionMemes = new string[]
            {
                "mems/2thumbs.jpg", // 0
                "mems/angery.jpg", // 1
                "mems/chuck.jpg", // 2
                "mems/hous.gif", // 3
                "mems/fukdoge.jpg", // 4
                "mems/mrrick.jpg", // 5
                "mems/nikita.png", // 6
                "mems/unnamed.jpg", // 7

            };

            roastSomeone = new string[]
            {
                "You'll never be the man your mother is.",
                "You're a failed abortion whose birth certificate is an apology from the condom factory",
                "You must have been born on a highway, because that's where most accidents happen",
                "It looks like your face caught on fire and someone tried to put it out with a fork",
                "You're so fucking fat, bro. How were YOU the fastest out of 100,000 sperm?",
                "Unless thats the sound of your body being dragged away, i dont wanna hear it",
                "Feel free to blow my asshole, you dirty shit.",
                "Your purposeless existence makes me want to drown puppies.",
                "You are disfigured and you smell like rectum relish.",
                "You have cholera. Don't cry however, it's not the worst thing that could happen. You're also going to die from it.",
                "I will kill you if you don't just stop being an insignificant cunt for at least the next 10 minutes..",
                "I often like to take a bath and picture you being murdered.",
                "Tonight I will take a giant juicy shit in the tank of your toilet.",
                "Hey thickness, I find your fat little fingers appalling.",
                "You're very nice. And by nice I really mean repelling.",
                "I pray that you get anal boils.",
                "There are rumors that your turn-ons consist of mommy touching and feces.",
                "Why the fuck do you smell so fucking nasty, did you play in the dumpster again?",
                "Nigga",
                "You will never have sex.",
                "You have an average sized penis",


            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterMemeCommand();
            RoastSomeoneCommand();
            RegisterSweepCommand();
            AinsleyMemeCommand();

            discord.ExecuteAndWait(async () =>
            {
            await discord.Connect(“kek”, TokenType.Bot);
            });
        }

        private void RegisterMemeCommand()
        {
            commands.CreateCommand("react")
                .Do(async(e) =>
                {
                    int RandomMemeIndex = rand.Next(reactionMemes.Length);
                    string MemeToPost = reactionMemes[RandomMemeIndex];
                    await e.Channel.SendFile(MemeToPost);
                });
        }

        private void AinsleyMemeCommand()
        {
            commands.CreateCommand("chuck")
                .Do(async (e) =>
                {
                    string MemeToPost = "mems/chuck.jpg";
                    await e.Channel.SendFile(MemeToPost);
                });
        }

        private void RoastSomeoneCommand()
        {
            commands.CreateCommand("roast")
                .Do(async (e) =>
                {
                    int RandomRoastIndex = rand.Next(roastSomeone.Length);
                    string roastSomeoneCommand = roastSomeone[RandomRoastIndex];
                    await e.Channel.SendMessage(roastSomeoneCommand);
                });
        }

        private void RegisterSweepCommand()
        {
            commands.CreateCommand("sweep")
                .Do(async (e) =>
                {
                    Message[] MessagesToDelete;
                    MessagesToDelete = await e.Channel.DownloadMessages(100);

                    await e.Channel.DeleteMessages(MessagesToDelete);
               });
        }




        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);

         }
      }
}
