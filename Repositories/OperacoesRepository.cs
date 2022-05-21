using System;

namespace calculadoraURL.Repositories
{
    public class OperacoesRepository
    {
        public string autoria { get; private set; } = "Criado por Ruan Lucas Rodrigues Costa";
        public string Autoria()
        {
            return autoria;
        }
        public string Ajuda()
        {
            string sobreLista = @"Para listar as operações insira ao fim da URL: api/operacoes/listar. ";
            string sobreOperacoes = "Para escolher operação insira ao fim da URL: api/operacoes/nomedaoperacao/primeironumero/segundonumero Ex.: api/operacoes/soma/1/1. ";
            string sobreFuncaoAfim = "Para calcular a função afim insira ao ao fim da URL: api/operacoes/funcaoafim/valoreA/valordeB/valordeX Ex.: api/funcaoafim/1/2/3. ";
            string sobreFuncaograu2 = "Para calcular a função do 2° Grau insira ao fim da URL: api/operacoes/funcaograu2/valordeA/valordeB/valordeC/valordeX";
            return sobreLista +  sobreOperacoes + sobreFuncaoAfim + sobreFuncaograu2;
        }
        public string ListarOperacoes()
        {
            return "Soma                    Subtração                    Multiplicação                    Divisão                    Função Afim                    Função do  2° Grau";
        }

        public double somar(double num1, double num2)
        {
            return num1 + num2;
        }

        public double subtracao(double num1, double num2)
        {
            return num1 - num2;
        }
        public double multiplicacao(double num1, double num2)
        {
            return num1 * num2;
        }

        public double divisao(double num1, double num2)
        { 
            return num1 / num2;
        }
        public string funcaoAfim(double a, double b, double? x)
        {
            if(x != null)
            {
                return $"f(x) = { a* x +b}";
            }
            //else if(a == null && b != null && x != null)
            //{
            //    return $"a ={-b / x}";
            //}
            //else if(b == null && a != null && x != null)
            //{
            //    return $"b = {-a * x}";
            //}
            else
            {
                x = -b / a;
                return $"x = {x}";
            }
        }
        public string funcao2grau(double a, double b, double c)
        {
            double delta = b * b - (4 * a * c);
            if(!double.IsNegative(delta))
            {
                var x1 = (-b + Math.Sqrt(delta))/(2 * a);
                var x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                var Xv = x1 + x2 / 2;
                var Yv = a * Xv * Xv + b * Xv + c;
                return $"Com delta em modulo: X' = {x1} ou {(-b + Math.Sqrt(delta))}/{(2 * a)}; X'' = {x2} ou {(-b - Math.Sqrt(delta))}/{(2 * a)}; Xv = {Xv}; Yv = {Yv}";
            }
            else
            {
                var deltaConvertido = delta * -1;
                var x1 = (-b + Math.Sqrt(deltaConvertido)) / (2 * a);
                var x2 = (-b - Math.Sqrt(deltaConvertido)) / (2 * a);
                var Xv = x1 + x2 / 2;
                var Yv = a * Xv * Xv + b * Xv + c;
                return $"Com delta em modulo: X' = {x1} ou {(-b + Math.Sqrt(deltaConvertido))}/{(2 * a)}; X'' = {x2} ou {(-b - Math.Sqrt(deltaConvertido))}/{(2 * a)}; Xv = {Xv}; Yv = {Yv}";

            }
        }
    }
}