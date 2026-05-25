# UI RPG

## OOP Principi

### Mantošana
- `Character` ir bāzes klase no kuras manto `Player` un `Enemy`
- `Weapon` ir bāzes klase no kuras manto `ChargeWeapon`, `CritWeapon` un `FlySwatter`
- `Enemy` no kuras manto `Mosquito`

### Enkapsulācija
- `Health` ir property ar getter un setter — setter nodrošina ka HP nekad nekrīt zem 0 (`Mathf.Max(0, value)`)
- `CharName` ir property tikai ar getter — vārdu nevar mainīt no ārienes
- Lauki kā `selectedWeapon`, `charName` utt. ir `private` vai `[SerializeField]`

### Polimorfisms
- **Override** — `Attack()` metode ir definēta kā `abstract` klasē `Character`, un katrs tēls to realizē savādāk: `Player` uzbrūk ar ieroci, `Enemy` uzbrūk ar nejaušu dmg
- **Overload** — `GetHit()` metodei ir 2 versijas klasē `Character`: viena pieņem `float` (pretinieka uzbrukums), otra pieņem `Weapon` (spēlētāja uzbrukums ar ieroci)

### Abstrakcija
- `Character` ir abstrakta klase ar abstraktu metodi `Attack()` — katram tēlam ir jārealizē sava uzbrukuma loģika
- `Weapon` ir bāzes klase ar virtuālu metodi `GetDamage()` ko manto:
  - `ChargeWeapon` — katrs sitienis kļūst spēcīgāks
  - `CritWeapon` — ir iespēja izdarīt kritisku sitienu x2 dmg
  - `FlySwatter` — strādā tikai pret moskītu

---

## Papildus uzdevumi

### 3 dažādi pretinieki
Ir 2 parastie `Enemy` un `Mosquito`. Moskītu var nogalināt tikai ar fly swatter. Citi ieroči pret moskītu nestrādā, un fly swatter nestrādā pret citiem pretiniekiem. Ja mēģina uzbrukt ar nepareizo ieroci, ekrānā parādās brīdinājuma teksts.

### 4 ieroču tipi
Ir 4 ieroči starp ko spēlētājs var pārslēgties ar pogu:
- Sword (flat dmg)
- `ChargeWeapon` (Axe, pieaugošs dmg)
- `CritWeapon` (Dagger, krits)
- `FlySwatter` (tikai pret moskītu)

### Healing
Spēlētājam ir heal poga kas atjauno 10 HP (vai atjauno līdz max ja trūkst mazāk par 10).

### Weapon switching
Spēles laikā var pamainīt izmantojamo ieroci. Ieroča tips atjaunojas UI.

---

## Bonuss

- Skaņas efekti — uzbrukumam, heal un pretinieka nāvei
- Pretinieka nāves skaņa skan random tonī
- Radošs papildinājums — fly swatter/moskītu mehānika
