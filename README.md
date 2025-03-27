# Cybersecurity Awareness Bot

## Description

The Cybersecurity Awareness Bot is a C# console application designed to educate users on various cybersecurity topics. 
The bot interacts with users by asking for their name and then provides information on different cybersecurity topics through a series of menu options. 
The bot's responses are displayed with a typing effect to simulate a more interactive experience.

## Features

- **Welcome Sound**: Plays a greeting sound using the NAudio library.
- **Interactive Menu**: Provides a list of cybersecurity topics that users can inquire about.
- **Typing Effect**: Displays responses as if they are being typed out.
- **Logo Display**: Shows a logo at the start of the program.
- **User Interaction**: Asks for the user's name and greets them.

## Requirements

- .NET 8.0
- NAudio library

## Installation

1. Clone the repository:
   git clone https://github.com/Sivi056/CybersecurityAwarenessBot.git

2. Navigate to the project directory:
   cd CybersecurityAwarenessBot

3. Restore the required packages:
   dotnet Restore

4. Build the project:
   dotnet Build

## Usage

1. Place the greeting sound file (`greeting.wav`) in the `Resources` directory within the project.

2. Run the application:
    dotnetRun


3. Follow the on-screen instructions to interact with the bot.

## Code Overview

### Main Program

The main program initializes the console, displays a logo, plays a welcome sound, and starts the main interaction loop.

static void Main() { // Set background color to grey Console.BackgroundColor = ConsoleColor.DarkGray; Console.Clear();
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

### RespondToUserInput Method

Handles user input and provides responses on various cybersecurity topics.

static void RespondToUserInput(string input, string userName) { switch (input.ToLower()) { case "1": case "how are you?": TypeEffect($"Unlike you, {userName}, I'm just a bot. I have no human feelings but I'm operating smoothly and ready to assist you with your cybersecurity questions."); break; case "2": case "what’s your purpose?": TypeEffect("My purpose is to provide you with information and guidance on cybersecurity topics. I can help you understand security concepts, answer your questions about threats and vulnerabilities, and offer advice on how to protect yourself and your organization."); break; case "3": case "what can i ask you about?": TypeEffect("You can ask me about a wide range of cybersecurity topics, including:
Password safety
Phishing and social engineering
Malware and viruses
Network security
Data privacy
Incident response
Safe browsing practices
Business Continuity and disaster recovery as it relates to security."); break; case "4": case "password safety": TypeEffect("Password safety is crucial. Here are some key tips:
Use strong, unique passwords for each of your accounts.
A strong password should be long (at least 12 characters) and include a mix of uppercase and lowercase letters, numbers, and symbols.
Consider using a password manager to securely store and generate your passwords.
Enable multi-factor authentication (MFA) whenever possible.
Avoid using easily guessable information in your passwords, such as your name, birthday, or pet's name.
Change your passwords regularly, especially if you suspect a breach."); break; case "5": case "phishing": TypeEffect("Phishing is a type of cyberattack that uses deceptive emails, messages, or websites to trick you into revealing sensitive information. Here's what to look out for:
Suspicious senders and email addresses.
Urgent or threatening language.
Requests for personal information.
Links or attachments from unknown sources.
Typos and grammatical errors.
Always verify the legitimacy of a request before providing any information. If you're unsure, contact the organization directly."); break; case "6": case "safe browsing": TypeEffect("Safe browsing practices can help protect you from online threats:
Keep your browser and operating system up to date.
Use a reputable antivirus and anti-malware software.
Avoid clicking on suspicious links or pop-up ads.
Be cautious when downloading files from the internet.
Use a secure VPN when using public Wi-Fi.
Check for the "HTTPS" and padlock icon in your browser's address bar."); break; case "7": case "malware and viruses": TypeEffect("Malware and viruses are malicious software that can harm your devices and steal your data. Protect yourself by installing antivirus software, keeping your software updated, and avoiding suspicious downloads or attachments."); break; case "8": case "disaster recovery": TypeEffect("Disaster recovery involves planning and implementing strategies to restore your systems and data after a disruptive event. This includes regular backups, off-site storage, and a recovery plan to minimize downtime."); break; case "9": case "data privacy": TypeEffect("Data privacy is about protecting your personal information. Be mindful of what you share online, use strong passwords, and understand the privacy policies of the websites and services you use."); break; case "10": case "network security": TypeEffect("Network security involves protecting your network from unauthorized access and cyberattacks. Use strong passwords for your Wi-Fi, enable a firewall, and keep your router's firmware updated. Consider using a VPN for added security."); break; default: TypeEffect("I didn’t quite understand that. Could you rephrase?"); break; } }

### PlayWelcomeSound Method

Plays a welcome sound using the NAudio library.

static void PlayWelcomeSound() { // Define the audio file path (ensure the path is correct) string audioFilePath = @"C:\Users\Sibusisiwe\OneDrive\Documents\C# WORK\POEPart1\POEPart1\invideo-ai-1080 Meet Your Cybersecurity Awareness Bot! 2025-03-26.wav";
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

### TypeEffect Method

Displays text with a typing effect.

static void TypeEffect(string message) { Console.ForegroundColor = ConsoleColor.Yellow; foreach (char c in message) { Console.Write(c); Thread.Sleep(30); // Adjusting the delay to control the typing speed } Console.WriteLine(); Console.ResetColor(); }

### DisplayLogo Method

Displays the logo at the start of the program.
static void DisplayLogo() { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(@"
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

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.




    

    
