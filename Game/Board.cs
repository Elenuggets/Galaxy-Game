namespace Game
{
    internal class Board
    {
        public Soldat[] list_Empire;
        public Soldat[] list_Rebelle;
        public Soldat hero_Empire;
        public Soldat hero_Rebelle;
        public Soldat favori;

        public Board(int nb_Empire, int nb_Rebelle)
        {
            // creation of the soldat
            list_Empire = new Soldat[nb_Empire];
            list_Rebelle = new Soldat[nb_Rebelle];
            for (int i = 0; i < nb_Empire; i++)
                list_Empire[i] = new Soldat("Stormtrooper_" + i);
            for (int i = 0; i < nb_Rebelle; i++)
                list_Rebelle[i] = new Soldat("Rebelle_" + i);

            // select the hero of each team
            hero_Empire = Hero(list_Empire);
            hero_Rebelle = Hero(list_Rebelle);

            // select the favori
            Random rand = new Random();
            int nb = rand.Next(0, nb_Rebelle + nb_Rebelle);
            if (nb < nb_Empire)
                favori = list_Empire[nb];
            else
                favori = list_Rebelle[nb - nb_Empire];
        }

        public Soldat Hero(Soldat[] list)
        {
            Soldat hero = list[0];
            int max = 0;
            for (int i = 1; i < list.Length; i++)
            {
                int score = list[i].GetHealth() + list[i].GetDamage() * 10;
                if (score > max)
                {
                    max = score;
                    hero = list[i];
                }
            }

            return hero;
        }

        public bool isFinish()
        {
            bool team_empire = false;
            bool team_rebelle = false;
            for (int i = 0; i < list_Empire.Length; i++)
            {
                if (!list_Empire[i].isDead())
                    team_empire = true;
            }
            for (int i = 0; i < list_Rebelle.Length; i++)
            {
                if (!list_Rebelle[i].isDead())
                    team_rebelle = true;
            }
            return !(team_empire && team_rebelle);
        }

        public void display()
        {
            Console.WriteLine("Empire array = ");
            for (int i = 0; i < list_Empire.Length; i++)
                list_Empire[i].print();
            Console.WriteLine("Rebelle array = ");
            for (int i = 0; i < list_Rebelle.Length; i++)
                list_Rebelle[i].print();
        }
    }
}
