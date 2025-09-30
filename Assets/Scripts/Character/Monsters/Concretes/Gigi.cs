using UnityEngine;

public class Gigi : Monster
{
    public override int LootReward { get => 5; }

    public override void InitializeMonster(string name)
    {
        Initialize(name, 21, 9);
    }

    public override void Attack(Character target)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>{Name} sings September 21 times to damage {target.Name}'s eardrum with {AttackPower} attack power</color>");
        target.TakeDamage(AttackPower);
    }

    public override void Attack(Character target, int bonusDamage)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>With powerful vengeance {Name} attacks {target.Name} with {bonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + bonusDamage);
    }

    public override void Roar()
    {
        Debug.Log("DO YOU REMEMBER");

        /*
        The 21st nightt of septemberr
        Love was changin the minds of pretenderrr
        While chasin' the clouds awaayyy

        Our hearts were ringin'
        In the key that our sould were singin'
        As we danced in the night, rememberr
        How the stars stole the night away, oh, yeah

        hey, Hey, HEY

        BAADEEYAA say do you remember!
        BAADEEYAA DANCING IN SEPTEMBER!
        BADEEYA Never was a cloudy dayyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy

        badudum badudum badudum baaadudum baadudum baadudum 

        My thoughts are with youu
        Holding hands with your heart to see you
        Only blue talk and love, remember
        How we know we love was here to stay

        Now December
        Found the love that we shared in September
        Only blue talk and love, rememer
        The true love we share today

        hey, Hey, HEY

        BAADEEYAA say do you remember!
        BAADEEYAA DANCING IN SEPTEMBER!
        BADEEYA Never was a cloudy dayyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy

        There was a
        BADEEYAA say, do you rememberr
        BADEEYAA dancin' in September
        BAADEEEYAAAA golden dreams were shiny dayyyyys

        baa de yaaa de yaa de yaaa
        baa de yaaa de yaa de yaaa
        baa de yaaa de yaa de yaa deeyaaaaaaa
         */
    }
}