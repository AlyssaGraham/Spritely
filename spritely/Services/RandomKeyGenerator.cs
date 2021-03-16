using System;

namespace spritely.Services
{
    public class RandomKeyGenerator
    {
        private readonly Random random;

        // url safe characters
        private readonly string[] possibleCharacters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
            "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0",
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "_", "~", "-" };

        public RandomKeyGenerator()
        {
            random = new Random();
        }

        public string getRandomString(int length)
        {
            var characters = "";

            for(var i=0; i<length; i++)
            {
                characters+= getRandomCharacter();
            }

            return characters;
        }

        private string getRandomCharacter()
        {
            return this.possibleCharacters[random.Next(0, possibleCharacters.Length)];
        }

    }
}
