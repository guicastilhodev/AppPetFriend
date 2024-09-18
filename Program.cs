//Animal atributtes
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation;


string[,] ourAnimals = new string[maxPets, 7];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "cachorro";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "cachorro retriever dourado fêmea de tamanho médio, cor creme.";
            animalPersonalityDescription = "brincalhona, adora carinho.";
            animalNickname = "lola";
            suggestedDonation = "85,00";
            break;

        case 1:
            animalSpecies = "cachorro";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "golden retriever, grande e marrom";
            animalPersonalityDescription = "ama brincar";
            animalNickname = "loki";
            suggestedDonation = "45,00";
            break;

        case 2:
            animalSpecies = "gato";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "femea pequena e treinada";
            animalPersonalityDescription = "amigável";
            animalNickname = "Doris";
            suggestedDonation = "60,00";
            break;

        case 3:
            animalSpecies = "gato";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Espécie: " + animalSpecies;
    ourAnimals[i, 2] = "Idade: " + animalAge;
    ourAnimals[i, 3] = "Nome: " + animalNickname;
    ourAnimals[i, 4] = "Descrição física: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personalidade: " + animalPersonalityDescription;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m;
    }
    ourAnimals[i, 6] = $"Doação sugerida: {decimalDonation:C2}";
}

do
{

    Console.Clear();

    Console.WriteLine("Bem vindo ao PetFriends app. Suas opções são:");
    Console.WriteLine(" 1. Lista de todas as informações sobre os nossos animais de estimação");
    Console.WriteLine(" 2. Adicionar um novo animal para nossa lista");
    Console.WriteLine(" 3. Assegurar que as idades dos animais e as descrições físicas estão completas");
    Console.WriteLine(" 4. Assegurar que os nomes e as descrições de personalidade estão completos");
    Console.WriteLine(" 5. Mostrar todos os cachorros com uma característica específica");
    Console.WriteLine(" 6. Mostrar todos os gatos com uma característica específica");
    Console.WriteLine();
    Console.WriteLine("Insira sua opção (ou escreva Sair para encerrar o programa)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\rAperte enter para continuar.");
            readResult = Console.ReadLine();
            break;
        case "2":
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"Temos {petCount} pets que precisam de um lar. Podemos cuidar de mais {(maxPets - petCount)}.");
            }

            bool validEntry = false;

            do
            {
                Console.WriteLine("\n\rInsira 'cachorro' ou 'gato' para inserir um novo pet");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalSpecies = readResult.ToLower();
                    if (animalSpecies != "cachorro" && animalSpecies != "gato")
                    {
                        validEntry = false;
                    }
                    else
                    {
                        validEntry = true;
                    }
                }
            } while (validEntry == false);

            animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

            do
            {
                int petAge;
                Console.WriteLine("Insira a idade do animal ou ? se desconhecido");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult;
                    if (animalAge != "?")
                    {
                        validEntry = int.TryParse(animalAge, out petAge);
                    }
                    else
                    {
                        validEntry = true;
                    }
                }

            } while (validEntry == false);

            do
            {
                Console.WriteLine("Insira uma descrição física do animal (tamanho, cor, sexo, peso, ...)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();
                    if (animalPhysicalDescription == "")
                        animalPhysicalDescription = "tbd";
                }

            } while (animalPhysicalDescription == "");


            do
            {
                Console.WriteLine("Descreva a personalidade do animal ");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalPersonalityDescription = readResult.ToLower();
                    if (animalPersonalityDescription == "")
                        animalPersonalityDescription = "tbd";
                }

            } while (animalPersonalityDescription == "");

            do
            {
                Console.WriteLine("Insira o nome do pet");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalNickname = readResult.ToLower();
                    if (animalNickname == "")
                        animalNickname = "tbd";
                }

            } while (animalNickname == "");

            ourAnimals[petCount, 0] = "ID #: " + animalID;
            ourAnimals[petCount, 1] = "Espécie: " + animalSpecies;
            ourAnimals[petCount, 2] = "Idade: " + animalAge;
            ourAnimals[petCount, 3] = "Nome: " + animalNickname;
            ourAnimals[petCount, 4] = "Descrição Física: " + animalPhysicalDescription;
            ourAnimals[petCount, 5] = "Personalidade: " + animalPersonalityDescription;


            while (anotherPet == "y" && petCount < maxPets)
            {
                petCount++;
                if (petCount < maxPets)
                {
                    Console.WriteLine("Quer adicionar outro pet? (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("Chegamos ao limite de pets que podemos cuidar.");
                Console.WriteLine("Aperte enter para continuar.");
                readResult = Console.ReadLine();
            }
            break;
        case "3":

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    bool validCurrentAnimalAge = false;
                    bool validNewAge = false;
                    bool validPhysicalDescription = false;

                    string currentAnimalAge = ourAnimals[i, 2].Substring(6).Trim();
                    int currentAnimalAgeValue;
                    string valueEntered = "";
                    int newAge;

                    validCurrentAnimalAge = int.TryParse(currentAnimalAge, out currentAnimalAgeValue);


                    if (!validCurrentAnimalAge)
                    {
                        if (!validCurrentAnimalAge)
                        {
                            Console.WriteLine($"Insira uma idade para {ourAnimals[i, 0]}");
                            do
                            {
                                readResult = Console.ReadLine();


                                if (readResult != null)
                                {
                                    valueEntered = readResult;
                                }

                                validNewAge = int.TryParse(valueEntered, out newAge);

                                if (validNewAge)
                                {
                                    ourAnimals[i, 2] = "Idade: " + valueEntered;
                                }

                            } while (!validNewAge);
                        }
                    }

                    if (ourAnimals[i, 4].Substring(17).Trim() == "" || ourAnimals[i, 4].Substring(17).Trim() == "tbd")
                    {
                        Console.WriteLine($"Insira uma descrição física para {ourAnimals[i, 0]} (tamanho, cor, gênero)");

                        do
                        {
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                ourAnimals[i, 4] = "Descrição física: " + readResult;
                                validPhysicalDescription = true;
                            }

                        } while (!validPhysicalDescription);
                    }
                }
            }
            Console.WriteLine("Idade e descrição física estão completas para nossos amigos");
            Console.WriteLine("Aperte enter para continuar.");
            readResult = Console.ReadLine();
            break;
        case "4":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {

                    bool validNickname = false;
                    bool validPersonalityDescription = false;

                    if (ourAnimals[i, 3].Substring(5).Trim() == "" || ourAnimals[i, 3].Substring(5).Trim() == "tbd")
                    {
                        Console.WriteLine($"Insira um nome para {ourAnimals[i, 0]}");

                        do
                        {
                            readResult = Console.ReadLine();

                            if (readResult != null && readResult.Length > 3)
                            {
                                ourAnimals[i, 3] = "Nome: " + readResult;
                                validNickname = true;
                            }

                        } while (!validNickname);
                    }

                    if (ourAnimals[i, 5].Substring(14).Trim() == "" || ourAnimals[i, 5].Substring(14).Trim() == "tbd")
                    {
                        Console.WriteLine($"Insira uma descrição da personalidade para {ourAnimals[i, 0]}");

                        do
                        {
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                ourAnimals[i, 5] = "Personalidade: " + readResult;
                                validPersonalityDescription = true;

                            }
                        } while (!validPersonalityDescription);
                    }
                }
            }
            Console.WriteLine("Nome e descrição personalidade estão completos para nossos amigos.");
            Console.WriteLine("Aperte enter para continuar..");
            readResult = Console.ReadLine();
            break;
        case "5":

            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                Console.WriteLine("\nEscreva as características desejadas separadas por vírgula");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower();
                    Console.WriteLine();
                }
            }

            string[] dogCharacteristicArray = dogCharacteristic.Split(",");
            for (int i = 0; i < dogCharacteristicArray.Length; i++)
            {
                dogCharacteristicArray[i] = dogCharacteristicArray[i].Trim();
            }
            Array.Sort(dogCharacteristicArray);
            bool matchesAnyDog = false;
            string dogDescription = "";

            string[] searchingIcons = { " |", " /", "--", " \\", " *" };

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("cachorro"))
                {


                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    bool matchesCurrentDog = false;

                    foreach (string characteristic in dogCharacteristicArray)
                    {
                        if (characteristic != null && characteristic.Trim() != "")
                        {
                            for (int j = 2; j > -1; j--)
                            {
                                foreach (string icon in searchingIcons)
                                {
                                    Console.WriteLine($"\rprocurando em nosso cachorro {ourAnimals[i, 3]} por {characteristic.Trim()} {icon} {j.ToString()}");
                                    Thread.Sleep(100);
                                }
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }

                            if (dogDescription.Contains(" " + characteristic.Trim() + " "))
                            {
                                Console.WriteLine($"\rNosso cachorro {ourAnimals[i, 3]} possui a característica {characteristic.Trim()}");

                                matchesCurrentDog = true;
                                matchesAnyDog = true;
                            }
                        }

                    }

                    if (matchesCurrentDog)
                    {
                        Console.WriteLine($"\r{ourAnimals[i, 3]} ({ourAnimals[i, 0]})\n{dogDescription}\n");
                    }
                }
            }

            if (!matchesAnyDog)
            {
                Console.WriteLine($"Nenhum de nossos colegas é compatível com {dogCharacteristic}");
            }
            Console.WriteLine("Aperte enter para continuar..");
            readResult = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine("Funcionalidade em desenvolvimento");
            Console.WriteLine("Aperte enter para continuar..");
            readResult = Console.ReadLine();
            break;

        case "sair":
            break;
        default:
            Console.WriteLine("Opção inválida, tente novamente...");
            Console.WriteLine("Aperte enter para continuar..");
            readResult = Console.ReadLine();
            break;
    }

} while (menuSelection != "sair");