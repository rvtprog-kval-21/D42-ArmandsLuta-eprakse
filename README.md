# D42-ArmandsLuta-eprakse
Elektroniskā prakses dienasgrāmata 
## Projekta apraksts
Šis projekts ļaus, pāriet no parastajām prakses grāmatiņām uz web aplikāciju/mājaslapu kur varēs skolas pieteikties, izveidot prakses notikumus, ievadīt savus datus datubāzē, Savienot ievadītos praktikantus ar izveidotiem prakses notikumiem. Praktikantas varēs apskatīties visas savas prakses - ierakstīt aktīvajās praksēs dienasgrāmatas ierakstus.
Uzņēmumi attiecīgi varēs pieņemt pieteiktos praktikantus vai atteikt viņus, ierakstīt cik un kādā profesīja viņi meklē praktikantus un uzņēmuma prakses vadītājs varēs ierakstit dienasgrāmatā vērtējumu un gala ierakstus.
## izmantotās tehnoloģijas
* power platforma
power platforma ir microsoft produkts ar mērķi dot iespēju veidot aplikācijas/mājaslapas/datubāzes bez vai ar ļoti minimālu koda palīdzību, protams ir arī iespējas izveidot pašam savas kontroles, loģiku, funkcijas visās power platformas daļās ar dažādām valodām - Javascript, Typescript, C++, C# utt. Pati power platforma sastāv no vairākām daļam, bet šajā projektā izmanto sekojošās daļas:
  * power apps (portal)
    * html
    * jquery
    * javascript
    * liquid
    * regex
    * xml
    * css
  * power automate
    * json
    * logic apps
    * xml
  * cds
    * sql
    * xml

Lai menedžētu uzdevumus kurus jaizpilda, un to statusus, kā arī dokumentācijas rakstīšana web aplikācijai tiek izmantots "Azure DevOps".
Ar azure DevOps palīdzību tiek saglabāts projekta source kods, tiek veikti automatizēti testi, izdoti uzdevumi starp mani un Kristapu, kas strādā ar mani kopā šajā projektā.
* azure
  * YAML (Deployment automatizācija)

Lai uzturētu sistemu, un lai būtu parlieciba, ka nekas netiek saplēsts, kad tiek izveidota jauna daļa programmai ir izveidota testa automatizācija, kas testē web aplikāciju pēc iepriekš nodefinētiem testiem.
Priekš testu veidošanas izmantoju Selenium WebDriver frameworku, kas ļāuj ātri un vienkārši sarakstīt testus, un dabūt to rezultātus.
Selenium WebDriver frameworku ir iespējams izmantot ar vairākām programmēšanas valodām Java, c#, python utt. Es izmantoju C#.
Testus un testa kodus var redzēt mapē "automatization".

## izmantotie avoti
  * https://learn.microsoft.com - mācījos power platformas rīkus
  * https://www.agarwalritika.com/post/filter-subgrid-on-entity-form-power-apps-portals - ņēmu pamatu javascript/jquery filtrēšanai


## uzstādīšanas instrukcijas
Redzēt kā lietotājs var vienkārši pagaidām izmantot šo mājas lapu - epraksedev.powerappsportals.com
