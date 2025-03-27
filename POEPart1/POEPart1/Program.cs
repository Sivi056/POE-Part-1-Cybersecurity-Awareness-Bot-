using System;
using System.Collections.Generic;
using NAudio.Wave;
using System.Threading;
using System.Media;
using System.Runtime.InteropServices;

namespace Part1
{
    class Program
    {
        public static object username { get; private set; }

        static void Main()
        {
            // Set background color to grey
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            // Display the logo
            DisplayLogo();

            // Play a welcome sound using NAudio
            PlayWelcomeSound();

            // Asking for the user's name and greet them.
            Console.Write("Please enter your name: ");

            string userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot.");
            Console.ResetColor();

            // Main interaction loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nWhat would you like to know about cybersecurity?");
                Console.WriteLine("1. How are you?");
                Console.WriteLine("2. What’s your purpose?");
                Console.WriteLine("3. What can I ask you about?");
                Console.WriteLine("4. Password safety");
                Console.WriteLine("5. Phishing");
                Console.WriteLine("6. Safe browsing");
                Console.WriteLine("7. Malware and viruses");
                Console.WriteLine("8. Disaster recovery");
                Console.WriteLine("9. Data Privacy");
                Console.WriteLine("10. Network Security");
                Console.WriteLine("Type 'exit' to quit.");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I didn’t quite understand that. Could you please pick an option from above?");
                    Console.ResetColor();
                    continue;
                }

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Farewell, {userName}! Remember to practice good cybersecurity.");
                    Console.ResetColor();
                    break;
                }

                RespondToUserInput(userInput, userName);
            }
            // Keeping the console open
            Console.ReadLine();
        }

        static void RespondToUserInput(string input, string userName)
        {
            switch (input.ToLower())
            {
                case "1":
                case "how are you?":
                    Console.WriteLine($"Unlike you, {userName}, I'm just a bot. I have no human feelings but I'm operating smoothly and ready to assist you with your cybersecurity questions.");
                    break;
                case "2":
                case "what’s your purpose?":
                    Console.WriteLine("My purpose is to provide you with information and guidance on cybersecurity topics. I can help you understand security concepts, answer your questions about threats and vulnerabilities, and offer advice on how to protect yourself and your organization.");
                    break;
                case "3":
                case "what can i ask you about?":
                    Console.WriteLine("You can ask me about a wide range of cybersecurity topics, including:\r\nPassword safety\r\nPhishing and social engineering\r\nMalware and viruses\r\nNetwork security\r\nData privacy\r\nIncident response\r\nSafe browsing practices\r\nBusiness Continuity and disaster recovery as it relates to security.");
                    break;
                case "4":
                case "password safety":
                    Console.WriteLine("Password safety is crucial. Here are some key tips:\r\nUse strong, unique passwords for each of your accounts.\r\nA strong password should be long (at least 12 characters) and include a mix of uppercase and lowercase letters, numbers, and symbols.\r\nConsider using a password manager to securely store and generate your passwords.\r\nEnable multi-factor authentication (MFA) whenever possible.\r\nAvoid using easily guessable information in your passwords, such as your name, birthday, or pet's name.\r\nChange your passwords regularly, especially if you suspect a breach.");
                    break;
                case "5":
                case "phishing":
                    Console.WriteLine("Phishing is a type of cyberattack that uses deceptive emails, messages, or websites to trick you into revealing sensitive information. Here's what to look out for:\r\nSuspicious senders and email addresses.\r\nUrgent or threatening language.\r\nRequests for personal information.\r\nLinks or attachments from unknown sources.\r\nTypos and grammatical errors.\r\nAlways verify the legitimacy of a request before providing any information. If you're unsure, contact the organization directly.");
                    break;
                case "6":
                case "safe browsing":
                    Console.WriteLine("Safe browsing practices can help protect you from online threats:\r\nKeep your browser and operating system up to date.\r\nUse a reputable antivirus and anti-malware software.\r\nAvoid clicking on suspicious links or pop-up ads.\r\nBe cautious when downloading files from the internet.\r\nUse a secure VPN when using public Wi-Fi.\r\nCheck for the \"HTTPS\" and padlock icon in your browser's address bar.");
                    break;
                case "7":
                case "malware and viruses":
                    Console.WriteLine("Malware and viruses are malicious software that can harm your devices and steal your data. Protect yourself by installing antivirus software, keeping your software updated, and avoiding suspicious downloads or attachments.");
                    break;
                case "8":
                case "disaster recovery":
                    Console.WriteLine("Disaster recovery involves planning and implementing strategies to restore your systems and data after a disruptive event. This includes regular backups, off-site storage, and a recovery plan to minimize downtime.");
                    break;
                case "9":
                case "data privacy":
                    Console.WriteLine("Data privacy is about protecting your personal information. Be mindful of what you share online, use strong passwords, and understand the privacy policies of the websites and services you use.");
                    break;
                case "10":
                case "network security":
                    Console.WriteLine("Network security involves protecting your network from unauthorized access and cyberattacks. Use strong passwords for your Wi-Fi, enable a firewall, and keep your router's firmware updated. Consider using a VPN for added security.");
                    break;
                default:
                    Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                    break;
            }
        }

        static void PlayWelcomeSound()
        {
            // Define the audio file path (ensure the path is correct)
            string audioFilePath = @"C:\Users\Sibusisiwe\OneDrive\Documents\C# WORK\POEPart1\POEPart1\invideo-ai-1080 Meet Your Cybersecurity Awareness Bot! 2025-03-26.wav";

            try
            {
                // Check if the file exists
                if (File.Exists(audioFilePath))
                {
                    using (var audioFile = new AudioFileReader(audioFilePath))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        // Wait until playback completes
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100); // Allow the audio to play
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Audio file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void TypeEffect(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30); // Adjusting the delay to control the typing speed
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"



                              
               *******************************     
               *******************************
               *******************************
               **********.-''''''-.***********
               ********.'           '.********
               *******/   O      O    \*******
               ******:                 :******
               ******|                 |****** 
                *****:    \       /    :*****
                 *****\    C S B      /******   
                  *****'.           .'******
                   ******'-......-'********
                    ********************** 
                      ******************
                        **************
                           *********
                             *****
                               *
                        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*           Your Digital Shield                     *");
            Console.WriteLine("*****************************************************");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}


