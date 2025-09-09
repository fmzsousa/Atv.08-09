public class Televisao
{
    private const int VOL_MIN = 0;
    private const int VOL_MAX = 100;
    private const int CANAL_MIN = 1;
    private const int CANAL_MAX = 520;

    private int ultimoCanal;

    public Televisao(float tamanho)
    {
        Tamanho = tamanho;
        Volume = 50;       // volume inicial padrão
        Canal = 1;         // começa no canal 1
        ultimoCanal = Canal;
        Estado = false;    // desligada por padrão
        Mudo = false;
    }

    public float Tamanho { get; }
    public int Resolucao { get; set; }
    public int Volume { get; private set; }
    public int Canal { get; private set; }
    public bool Estado { get; private set; }
    public bool Mudo { get; private set; }

    // ------------------- Controle de Energia -------------------
    public void Ligar()
    {
        Estado = true;
        Canal = ultimoCanal; // ao ligar volta para o último canal
        Console.WriteLine($"TV ligada no canal {Canal}");
    }

    public void Desligar()
    {
        Estado = false;
        ultimoCanal = Canal; // guarda o último canal assistido
        Console.WriteLine("TV desligada");
    }

    // ------------------- Controle de Volume -------------------
    public void AumentarVolume()
    {
        if (Estado)
        {
            if (Volume < VOL_MAX)
            {
                Volume++;
                Mudo = false;
            }
            else
            {
                Console.WriteLine("Volume já está no máximo.");
            }
        }
    }

    public void ReduzirVolume()
    {
        if (Estado)
        {
            if (Volume > VOL_MIN)
            {
                Volume--;
                Mudo = false;
            }
            else
            {
                Console.WriteLine("Volume já está no mínimo.");
            }
        }
    }

    public void AtivarMudo()
    {
        if (Estado)
        {
            Mudo = true;
            Console.WriteLine("Mudo ativado.");
        }
    }

    public void DesativarMudo()
    {
        if (Estado)
        {
            Mudo = false;
            Console.WriteLine($"Volume restaurado: {Volume}");
        }
    }

    // ------------------- Controle de Canais -------------------
    public void ProximoCanal()
    {
        if (Estado)
        {
            Canal = (Canal < CANAL_MAX) ? Canal + 1 : CANAL_MIN;
            Console.WriteLine($"Canal: {Canal}");
        }
    }

    public void CanalAnterior()
    {
        if (Estado)
        {
            Canal = (Canal > CANAL_MIN) ? Canal - 1 : CANAL_MAX;
            Console.WriteLine($"Canal: {Canal}");
        }
    }

    public void IrParaCanal(int numero)
    {
        if (Estado)
        {
            if (numero >= CANAL_MIN && numero <= CANAL_MAX)
            {
                Canal = numero;
                Console.WriteLine($"Canal: {Canal}");
            }
            else
            {
                Console.WriteLine("Canal inválido!");
            }
        }
    }
}
