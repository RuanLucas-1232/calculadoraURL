using System;

namespace calculadoraURL.Repositories
{
    public class OperacoesDeInstalacoesRepository
    {
        public string autoria { get; private set; } = "Criado por Ruan Lucas Rodrigues Costa;";

        double[,] tabelaTrigonometrica = { { 0.5, Math.Sqrt(2) / 2, Math.Sqrt(3) / 2 }, { Math.Sqrt(3) / 2, Math.Sqrt(2) / 2, 0.5 }, { Math.Sqrt(3) / 3, 1, Math.Sqrt(3) } };

        public string Autoria()
        {
            return autoria;
        }
        public string[] sobre()
        {
            string[,] documentacao = { { "Para calcular o diâmetro da tubulação usa-se na url: diametro/{Q}/{V}/{unidademedida de Q}/{Densidade: opicional colocar}. Na unidade usa-se (:) ao invéde (/). Ex.: m^3:h" }, { "Para calcular o Hu usa-se na url: hu /{Q}/{diametro}/{constante}" }, { "Para calcular o Ht em tubulaç. retas usa-se na url: httubulacaoreta/{hu}/{l}" }, { "Para calcular o Ht em tubulaç. descontínuas usa-se na url: httubulacaods/{hu}/{l1}/{l2}/{l3}/{Desníveo}" }, { "Para calcular o com a trigonometria tubulaç. inclinadas usa-se na url: trgco/{angulo}/{co}/{hi: opicional colocar}" }, { "Para calcular o com a trigonometria tubulaç. inclinadas usa-se na url: trgca/{angulo}/{ca}/{hi: opicional colocar}; " }, { "Para calcular o com a trigonometria tubulaç. inclinadas usa-se na url: trghi/{angulo}/{hi}/{ca: opicional colocar}" }, { "Para calcular o Ht em tubulaç. descontínuas usa-se na url: httubulacaoinc/{hu}/{l}/{Desníveo}" }};
            var doc1 = documentacao[0,0];
            var doc2 = documentacao[1, 0];
            var doc3 = documentacao[2, 0];
            var doc4 = documentacao[3, 0];
            var doc5 = documentacao[4, 0];
            var doc6 = documentacao[5, 0];
            var doc7 = documentacao[6, 0];
            var doc8 = documentacao[7, 0];
            return new[] { doc1, doc2, doc3, doc4, doc5, doc6, doc7 };
        }
        public string DiametroTubulacao(double Q, double V, string UnidadeMedidaQ, string? Densidade)
        {
            UnidadeMedidaQ = UnidadeMedidaQ.Replace(":", "/");
            if (UnidadeMedidaQ == "m^3/h")
            {
                double Area = (Q / 3600) / V;
                double D = Area * 4 / 3.14;
                double Diametro = Math.Sqrt(D);
                return $"Diâmetro = {Diametro}m";
            }
            else if (UnidadeMedidaQ == "m^3/s")
            {
                double Area = Q / V;
                double D = Area * 4 / 3.14;
                double Diametro = Math.Sqrt(D);
                return $"Diâmetro = {Diametro}m";
            }
            else if (UnidadeMedidaQ == "l/h")
            {
                double Area = ((Q / 1000) / 3600) / V;
                double D = Area * 4 / 3.14;
                double Diametro = Math.Sqrt(D);
                return $"Diâmetro = {Diametro}m";
            }
            else if (UnidadeMedidaQ == "l/s")
            {
                double Area = (Q / 1000) / V;
                double D = Area * 4 / 3.14;
                double Diametro = Math.Sqrt(D);
                return $"Diâmetro = {Diametro}m";
            }
            else if (UnidadeMedidaQ == "Kg/h")
            {
                double Vazao = (double)(Q * double.Parse(Densidade));
                double Area = (Vazao / 3600) / V;
                double D = Area * 4 / 3.14;
                double Diametro = Math.Sqrt(D);
                return $"Diâmetro = {Diametro}m";
            }
            else if (UnidadeMedidaQ == "Kg/s")
            {
                int IndexCaracter = Densidade.IndexOf("/");
                double VolumeDensidade = double.Parse(Densidade.Substring(0, IndexCaracter));
                double MassaDensidade = double.Parse(Densidade.Substring(IndexCaracter + 1));
                double Vazao = (double)(Q * VolumeDensidade / MassaDensidade);
                double Area = Vazao / V;
                double D = Area * 4 / 3.14;
                double Diametro = Math.Sqrt(D);
                return $"Diâmetro = {Diametro}m";
            }
            else
            {
                return "Use as unidades de medida da vazão no formato: m^3:h, m^3:s, l:h, l:s, Kg:h e Kg:s";
            }
        }
        public string PerdaCargaUnitaria(double q, double d, string constanteMaterialTubulaçao)
        {
            if (constanteMaterialTubulaçao == "aco")
            {
                double divisao = q / 110;
                double Hu0 = Math.Pow(divisao, 1.85);
                double Hu1 = Math.Pow(d, -4.87);
                double Hu = 10.64 * Hu0 * Hu1;
                return $"Hu = {Hu} mca/mdt";
            }
            else if (constanteMaterialTubulaçao == "pvc")
            {
                double Hu0 = Math.Pow((q / 140), 1.85);
                double Hu1 = Math.Pow(d, -4.87);
                double Hu = 10.64 * Hu0 * Hu1;
                return $"Hu = {Hu} mca/mdt";
            }
            else
            {
                return "Digite a constatnte do material no formato: aco (aço) ou pvc (em minúsculo)";
            }
        }
        public string PercaCargaTotalTubulacaoReta(double Hu, double L)
        {
            return $"Ht = {Hu * L}mca";
        }
        public string PercaCargaTotalTubulacaoDescontinua(double Hu, double L1, double L2, double L3, double Dl)
        {
            double L = L1 + L2 + L3;
            return $"Ht = {(Hu * L) + Dl}mca";
        }
        public string TrgCo(double angulo, double Co, double? hi)
        {
            if (angulo == 30)
            {
                //H^2=CA^2+CO^2
                double sen = tabelaTrigonometrica[0, 0];
                hi = Co / sen;

                double PitagorasCa = Math.Sqrt((Math.Pow((double)(hi), 2) - Math.Pow(Co, 2)));

                double tg = tabelaTrigonometrica[2, 0];
                double CatetoAdj = (double)(Co) / tg;

                double PitagorasHi = Math.Sqrt((Math.Pow(Co, 2) + Math.Pow(CatetoAdj, 2)));
                return $"Pelo sen {angulo}°: Hipotenusa = {hi}m e Cateto Adjacente = {PitagorasCa}m; Pela tg {angulo}°: Cateto Adjacente = {CatetoAdj}m e Hipotenusa = {PitagorasHi}m";
            }
            else if (angulo == 45)
            {
                double sen = tabelaTrigonometrica[0, 1];
                hi = Co / sen;

                double PitagorasCa = Math.Sqrt((Math.Pow((double)(hi), 2) - Math.Pow(Co, 2)));

                double tg = tabelaTrigonometrica[2, 1];
                double CatetoAdj = (double)(Co) / tg;

                double PitagorasHi = Math.Sqrt((Math.Pow(Co, 2) + Math.Pow(CatetoAdj, 2)));
                return $"Pelo sen {angulo}°: Hipotenusa = {hi}m e Cateto Adjacente = {PitagorasCa}m; Pela tg {angulo}°: Cateto Adjacente = {CatetoAdj}m e Hipotenusa = {PitagorasHi}m";
            }
            else if (angulo == 60)
            {
                double sen = tabelaTrigonometrica[0, 2];
                hi = Co / sen;

                double PitagorasCa = Math.Sqrt((Math.Pow((double)(hi), 2) - Math.Pow(Co, 2)));

                double tg = tabelaTrigonometrica[2, 2];
                double CatetoAdj = (double)(Co) / tg;

                double PitagorasHi = Math.Sqrt((Math.Pow(Co, 2) + Math.Pow(CatetoAdj, 2)));
                return $"Pelo sen {angulo}°: Hipotenusa = {hi}m e Cateto Adjacente = {PitagorasCa}m; Pela tg {angulo}°: Cateto Adjacente = {CatetoAdj}m e Hipotenusa = {PitagorasHi}m";
            }
            else
            {
                return "Desculpa, a calculadora só calcula ângulos de 30°, 45° e 60°";
            }
        }
        public string TrgCa(double angulo, double Ca, double? hi)
        {
            if (angulo == 30)
            {

                double cos = tabelaTrigonometrica[1, 0];
                hi = Ca / cos;

                double PitagorasCo = Math.Sqrt((Math.Pow((double)(hi), 2) + Math.Pow(Ca, 2)));

                double tg = tabelaTrigonometrica[2, 0];
                double CatetoOpst = tg * Ca;

                double PitagorasHi = Math.Sqrt(Math.Pow(Ca, 2) + Math.Pow(CatetoOpst, 2));
                return $"Pelo cos {angulo}°: Hipotenusa = {hi}m e Cateto Oposto = {PitagorasCo}m; Pela tg {angulo}°: Cateto oposto = {CatetoOpst}m e Hipotenusa = {PitagorasHi}m";
            }
            else if (angulo == 45)
            {
                double cos = tabelaTrigonometrica[1, 1];
                hi = Ca / cos;

                double PitagorasCo = Math.Sqrt((Math.Pow((double)(hi), 2) + Math.Pow(Ca, 2)));

                double tg = tabelaTrigonometrica[2, 1];
                double CatetoOpst = tg * Ca;

                double PitagorasHi = Math.Sqrt(Math.Pow(Ca, 2) + Math.Pow(CatetoOpst, 2));
                return $"Pelo cos {angulo}°: Hipotenusa = {hi}m e Cateto Oposto = {PitagorasCo}m; Pela tg {angulo}°: Cateto oposto = {CatetoOpst}m e Hipotenusa = {PitagorasHi}m";
            }
            else if (angulo == 60)
            {
                double cos = tabelaTrigonometrica[1, 2];
                hi = Ca / cos;

                double PitagorasCo = Math.Sqrt((Math.Pow((double)(hi), 2) + Math.Pow(Ca, 2)));

                double tg = tabelaTrigonometrica[2, 2];
                double CatetoOpst = tg * Ca;

                double PitagorasHi = Math.Sqrt(Math.Pow(Ca, 2) + Math.Pow(CatetoOpst, 2));
                return $"Pelo cos {angulo}°: Hipotenusa = {hi}m e Cateto Oposto = {PitagorasCo}m; Pela tg {angulo}°: Cateto oposto = {CatetoOpst}m e Hipotenusa = {PitagorasHi}m";
            }
            else
            {
                return "Desculpa, a calculadora só calcula ângulos de 30°, 45° e 60°";
            }
        }
        public string TrgHi(double angulo, double hi, double? Ca)
        {
            if (angulo == 30)
            {
                double cos = tabelaTrigonometrica[1, 0];
                Ca = cos * hi;

                double PitagorasCo = Math.Sqrt(Math.Pow(hi, 2) - Math.Pow((double)(Ca), 2));

                double sen = tabelaTrigonometrica[0, 0];
                double CatetoOpst = sen * hi;

                double PitagorasCa = Math.Sqrt(Math.Pow(hi, 2) - Math.Pow(CatetoOpst, 2));
                return $"Pelo cos {angulo}°: Cateto Adjacente = {Ca}m e Cateto Oposto = {PitagorasCo}m; Pelo sen {angulo}°: Cateto oposto = {CatetoOpst}m e Cateto Adjacente = {PitagorasCa}m";
            }
            else if (angulo == 45)
            {
                double cos = tabelaTrigonometrica[1, 1];
                Ca = cos * hi;

                double PitagorasCo = Math.Sqrt(Math.Pow(hi, 2) - Math.Pow((double)(Ca), 2));

                double sen = tabelaTrigonometrica[0, 1];
                double CatetoOpst = sen * hi;

                double PitagorasCa = Math.Sqrt(Math.Pow(hi, 2) - Math.Pow(CatetoOpst, 2));
                return $"Pelo cos {angulo}°: Cateto Adjacente = {Ca}m e Cateto Oposto = {PitagorasCo}m; Pelo sen {angulo}°: Cateto oposto = {CatetoOpst}m e Cateto Adjacente = {PitagorasCa}m";
            }
            else if (angulo == 60)
            {
                double cos = tabelaTrigonometrica[1, 2];
                Ca = cos * hi;

                double PitagorasCo = Math.Sqrt(Math.Pow(hi, 2) - Math.Pow((double)(Ca), 2));

                double sen = tabelaTrigonometrica[0, 2];
                double CatetoOpst = sen * hi;

                double PitagorasCa = Math.Sqrt(Math.Pow(hi, 2) - Math.Pow(CatetoOpst, 2));
                return $"Pelo cos {angulo}°: Cateto Adjacente = {Ca}m e Cateto Oposto = {PitagorasCo}m; Pelo sen {angulo}°: Cateto oposto = {CatetoOpst}m e Cateto Adjacente = {PitagorasCa}m";
            }
            else
            {
                return "Desculpa, a calculadora só calcula ângulos de 30°, 45° e 60°";
            }
        }
        public string PercaCargaTotalTubulacaoInclinada(double Hu, double L, double Dl)
        {
            return $"Ht = {Hu * L + Dl}mca";
        }
    }
}
