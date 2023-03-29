using System;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parametros de trabajo :
            int[,] datos = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 1, 1 }, { 0, 0, 0 } };
            Random aleatorio = new Random();
            double[] pesos = { aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble() };
            bool aprendizaje = true;
            int salidaInt;
            int pasos = 0;

            //Inicia Aprendizaje
            while (aprendizaje)
            {
                aprendizaje = false;
                for (int i = 0; i < 4; i++)
                {
                    double salidadDoub = datos[i, 0] * pesos[0] + datos[i, 1] * pesos[1] + pesos[2];

                    //Funcion de activacion
                    salidadDoub = salidadDoub - Math.Pow(salidadDoub, 2);
                    if (salidadDoub > 0) salidaInt = 1;
                    else salidaInt = 0;

                    if (salidaInt != datos[i, 2])
                    {
                        pesos[0] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[1] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[2] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        aprendizaje = true;
                        i = 4;
                    }
                }
                pasos++;
            }
            //Fin del aprendizaje

            //Verificacion de las salidas
            for (int i = 0; i < 4; i++)
            {
                double salidadDoub = datos[i, 0] * pesos[0] + datos[i, 1] * pesos[1] + pesos[2];
                salidadDoub = salidadDoub - Math.Pow(salidadDoub, 2);
                if (salidadDoub > 0) salidaInt = 1;
                else salidaInt = 0;
                Console.WriteLine("Entradas:" + datos[i, 0].ToString() + " XOR " + datos[i, 1].ToString() + " = " + datos[i, 2].ToString()
                    + "| Perceptron: " + salidaInt.ToString());
            }
            //Mostrar los pesos utiles
            Console.WriteLine(
                "Pesos utiles: w0 = " + pesos[0] +
                " w1 = " + pesos[1] +
                " bias = " + pesos[2]);
            Console.WriteLine("Pasos " + pasos);
            Console.ReadLine();
        }

    }
}
