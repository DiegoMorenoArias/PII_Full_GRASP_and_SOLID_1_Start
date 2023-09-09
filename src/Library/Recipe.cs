//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        public static double inputCost;
        public static double equipmentCost;
        public static double totalCost;
        public ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        public double GetProductionCost()
        {
            foreach (Step step in steps)
            {
                inputCost+=(step.Input.UnitCost/1000)*step.Quantity;
                equipmentCost+=step.Equipment.HourlyCost/3600*step.Time;
            }
            totalCost=inputCost+equipmentCost;
            return totalCost;
        }
        // Principio SRP: No se cumple pues la clase tiene más de una responsabilidad, calcular su costo e imprimir...
        // Principio Expert: La clase tiene toda la información necesaria para calcular el costo, entonces no se asigna otra clase que reciba
        // todas estas informaciones sino simplemente se hace dentro de ella.

        // Para cumplir con el Principio SRP, se podría considerar separar la responsabilidad de imprimir en una
        // clase diferente (como se hizo en el ejercicio 2), lo que mejoraría la cohesión y la claridad del diseño.
    }
}