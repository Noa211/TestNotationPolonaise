using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// calcul en notation polonaise
        /// </summary>
        /// <param name="formule">formule à calculer</param>
        /// <returns></returns>
        static float Polonaise(String formule)
        {
            try
            {
                string[] calcul = formule.Split(' ');
                for (int k = (calcul.Length - 1); k >= 0; k--)
                {
                    if (calcul[k] == "+" || calcul[k] == "-" || calcul[k] == "*" || calcul[k] == "/")
                    {
                        switch (calcul[k])
                        {
                            case "+" :
                                calcul[k] = (float.Parse(calcul[k + 1]) + float.Parse(calcul[k + 2])).ToString();
                                break;
                            case "-":
                                calcul[k] = (float.Parse(calcul[k + 1]) - float.Parse(calcul[k + 2])).ToString();
                                break;
                            case "*":
                                calcul[k] = (float.Parse(calcul[k + 1]) * float.Parse(calcul[k + 2])).ToString();
                                break;
                            case "/":
                                calcul[k] = (float.Parse(calcul[k + 1]) / float.Parse(calcul[k + 2])).ToString();
                                break;
                        }
                        for (int j = k + 1; j < calcul.Length - 2; j++)
                        {
                            calcul[j] = calcul[j + 2];
                            calcul[j + 1] = " ";
                            calcul[j + 2] = " ";
                        }
                    }
                }
                if (calcul.Length == 1 || calcul[1] == " ")
                {
                    return float.Parse(calcul[0]);
                }
                else
                {
                    return float.NaN;
                }
            }
            catch
            {
                return float.NaN;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                String laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
