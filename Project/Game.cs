using System;
using System.Collections.Generic;
using System.Linq;

namespace CastleGrimtol.Project
{

    public class Game : IGame
    {
        public bool Running = false;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }


        public void Run()
        {
            Running = true;
            while (Running)
            {



                #region 
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                #region 
                System.Console.WriteLine(@"
                   (               (                        (      (        *                  )    (     
   (       (       )\ )    *   )   )\ )            (        )\ )   )\ )   (  `      *   )   ( /(    )\ )  
   )\      )\     (()/(  ` )  /(  (()/(   (        )\ )    (()/(  (()/(   )\))(   ` )  /(   )\())  (()/(  
 (((_)  ((((_)(    /(_))  ( )(_))  /(_))  )\      (()/(     /(_))  /(_)) ((_)()\   ( )(_)) ((_)\    /(_)) 
 )\___   )\ _ )\  (_))   (_(_())  (_))   ((_)      /(_))_  (_))   (_))   (_()((_) (_(_())    ((_)  (_))   
((/ __|  (_)_\(_) / __|  |_   _|  | |    | __|    (_)) __| | _ \  |_ _|  |  \/  | |_   _|   / _ \  | |    
 | (__    / _ \   \__ \    | |    | |__  | _|       | (_ | |   /   | |   | |\/| |   | |    | (_) | | |__  
  \___|  /_/ \_\  |___/    |_|    |____| |___|       \___| |_|_\  |___|  |_|  |_|   |_|     \___/  |____| 
                                                                                                          
");
                #endregion
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.Write(" Current Room: ");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(CurrentRoom.Name + " "); //  + CurrentRoom.Exits.Values   trying to display exits of currentroom
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(" " + CurrentRoom.Description);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                System.Console.Write(" Directions/");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var exit in CurrentRoom.Exits)
                {
                    System.Console.Write(exit.Key + "/");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(@"");

                System.Console.WriteLine(" type ( help ) for all commands");
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.Write(" What would you like to do?");
                Console.ForegroundColor = ConsoleColor.White;
                var input = handleInput();
                #endregion


                switch (input.ToLower())
                {

                    // case "unlock":

                      

                    //         if (CurrentPlayer.Inventory.Find(item => item.Name == "lockpick") != null)
                    //         {
                    //            foreach (var exit in CurrentRoom.Exits)
                    //            {
                    //                locked = false;
                    //            }
                    //         }
                    //         else
                    //         {
                    //             continue;
                    //         }
                        
                    //     else { continue; }

                    case "help":
                        help();
                        System.Console.WriteLine("Press enter to return.");
                        System.Console.ReadLine();
                        continue;
                    case "inv":
                        if (CurrentPlayer.Inventory.Count == 0)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("YOU HAVE NOTHING!!! HAHAHAHHA");
                        }
                        else if (CurrentPlayer.Inventory.Count > 0)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("Youfind: ");

                            foreach (var item in CurrentPlayer.Inventory)
                            {
                                System.Console.Write($"{item.Name} \"{item.Description}\" | ");
                            }

                        }
                        System.Console.WriteLine(" Enter to continue");
                        System.Console.ReadLine();
                        continue;


                    case "take":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach (var item in CurrentRoom.Items)
                        {
                            System.Console.Write($"{item.Name} \"{item.Description}\" | ");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write("What would you like to take? ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        string input6 = System.Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        take(input6);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        System.Console.Write("Current Inventory: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var item in CurrentPlayer.Inventory)
                        {
                            System.Console.Write(item.Name);
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine(" Enter to continue");
                        System.Console.ReadLine();
                        continue;


                    
                    case "escape":

                        if (CurrentRoom.Name == "6")
                        {

                            if (CurrentPlayer.Inventory.Find(item => item.Name == "treasure") != null)
                            {
                                System.Console.WriteLine("WINNER!!");
                                System.Environment.Exit(0);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else { continue; }

                    case "look":
                        if (CurrentRoom.Items.Count == 0)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("You look around and find nothing");
                        }
                        else if (CurrentRoom.Items.Count > 0)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("You look around and find: ");

                            foreach (var item in CurrentRoom.Items)
                            {
                                System.Console.Write($"{item.Name} \"{item.Description}\" | ");
                            }

                        }
                        System.Console.WriteLine(" Enter to continue");
                        System.Console.ReadLine();
                        continue;
                    case "q":
                        Console.WriteLine("Excellent!");
                        System.Environment.Exit(0);
                        continue;

                    case "n":
                        if (CurrentRoom.Exits.ContainsKey("north"))
                        {
                            go("n");
                        }
                        continue;
                    case "e":
                        if (CurrentRoom.Exits.ContainsKey("east"))
                        {
                            go("e");
                        }
                        else
                        {
                            Console.Clear();
                            #region 
                            System.Console.Write(@"
                            
                                                                                                                                                                                                                
                                                                                                                                                                          `.---.                        
                                                                                                                                                         ``   `.:/::/:..-/:----:+.                      
                                                                                                                                             ``.......:/::::::::......--....--..+.                      
                                                                                                                                   `.`    .:/:::::--:-...................../++..+`                      
                                                                                                                       ```      .//::::::/:...............................:++/..:/                      
                                                                                                                    ./:::::::::::.........................................:+/-...:/`                    
                                                                                                                   :++-.......--.............................-.....s-......-......:/                    
                                                                                                                ``:+.-////:..:+++/-...............-:........-h:.-::m/:-./h-.......-+                    
                                                                                                            .:::/::-......+:.-+++++:............../h.........odo+/:://+od+........-+                    
                                                                                                          `+:-.......-/o+--+..:+++++-......-o...--:h:--....+s/.        `.+s/......./-                   
                                                                                                          -+......../ssss/.o-..-/+++:.......oh+o+++++++oo/y/`       `..`  .so.......+-                  
                                                                                                        `.+-.......:sssss:./:.....--....-.-+s/.`     ` `./y+`     `+yssys. `y+.......+`                 
                                                                                                       :/:-........+ssss/..:+-...-:....-oyy/`     :osys+. `/y.    sh+ymhsd. /y......./-                 
                                                                                                      `o-..........+sso:....-//:./+/-...:h.      shoososh:  -h.   ds+mMN+do /y.......+-                 
                                                                                                       .//-.........--.........//-/+/...y/      :m+sNMNosd`  +s   yh+ydy+do-hy+/.....+.                 
                                                                                                         .+-....................+:.:-...h.      :d+sMMNs+m.  :d   `yhooohms/:-:sy..../:                 
                                                                                                          -+.....-+/-...........:+......h-      `hs+shs+sh`  :h     :odh+-.....+h.....+.                
                                                                                                          `+-....-oso:..........-o......oy       .sysssyy.   yyo+//+o+:......-oy-.....-+                
                                                                                                           -+-....-/s+..........-o.......so`       .:/:.   `ss.+ys/-....--:+ss:........+.               
                                                                                                            .//:-...--...........//......./y/`           `/y/.../++o++ooooyh+/::-......+.               
       `+`   `:.                                      ``   -:              `:-               /:               `./:................//-......./so/-.```.-/os/.....-:::--.....-/+sd/.....//                
     :o/N/o: -Mo                                     `hy   mN              .yo            `o/my+o                +-................-//......---//+++++/:.............--:++oosd/...::-.:/                
     `:mmm/` -Mo`//:.   `/.-/:`  .://-`    `.://:.  .+Md/- mm`-//-`        `/:  :/`-//:`   -ymNo.                +:........../o+-....o:-/...:-............://+++oosydo//:. ``h:.-++++-.+.               
      +o o+  -Mmh++sNy` -Mms+o`-dmo++hm/  -ddo++yMs .+Md/. dNho+odm-       .My  hMhs++dN:  -s`:s`               `+-.........+sss+...-+.....-:.......-/oohy/:--.`` /o+sooysosyyy.:++++/./:               
             -Ms    :Ms -My   `mN:::::hM- -/` `.-mN  `Mh   dM`   -Ms       .My  hM.   .My                        //........:sssso-..+:.....--....:sso/-.+y        `h/m-.sh--h+d.:++++/.+`               
             -M/    `Mh .Ms   .Mmoooooo+- -yddhyomN  `Mh   mN    -Ms       .My  hM`   `Mh                         -//-.....+sssso..-+...........ys-.....-h`     /ysdm-.yo..shyh../+++./:                
             -Md`   sM/ .Ms    hN:   `sy` NN`   -NN` `Mh   mm    -Ms       .My  hM`   `Mh                           `+-..../ssss/..:+...........-........ho+oooyd.-m:.h+..+N+.dh..--../-                
             -Myhddmy-  .Ms     +ddhdmy-  /dmhhhsyN.  yNmo mm    -Ms       .My  hN`   `Mh                            /:....-oss/....+-.....:/:...........-:..--oh.h+.yo../d-.ysh/...-.-+                
              `   `      `         ``        `    `     `  ``     `         `    `     `                            `+-......--.....-o-...///-........:::::::-.ssoy.sy../h--h+-d..:++-.+yo+:`           
                                                                                                                    :+................+/......................ys./../-./d-.h+.+y../+:..-+``:os/.        
                                                                                                                     //-..............+/....................-y+........--.yo../h.......+/   ``-yo       
                                                                                                                      `/:............/+.......-:-...........oy...........ss....h:-:::/:h:+ho: -h-       
                                                                                                                       -+....::......+:.....-/++/...........-ss:........ss..../dyo:``` hN/:sos+`        
                                                                                                                      `+:.../so-..-::so:...-++++-.............-sh..//+oyho+osho:.-+oo/-dsss./yo.        
                                                                                                                      :/....+o:..so/://++ooso+/-..............-h+.+mydd+.``-y/-+so/--:/ssymy..:ss-      
                                                                                                                      +-........oy       `.-+ss+:........::::/dy.-dhydy/oo/y-   `./oo+/-.---....-os-    
                                                                                                                      -/---/-.-.ss            `-+s+:-::/yo-`:dd-.smhhmo  `:`  `.-:/+shddso+//:--..-d-   
                                                                                                                       `.-.dh:::/d.           .- `sy``` `-+soh:./mysssds-/+ossyssssssysd/`..://++oos.   
                                                                                                                           hs/oo+sy`        .sd/.`oo       .y+.-dhsssssmdsyyyy+odmNNNNmh/        ``     
                                                                                                                           sdso+/:sy.      -h::/+oh+:---:+oh+..ymsssssdMNNNMMm+omdhyys+h+               
                                                                                       ```.`                               +h+ossyydd/.    hy+:-..-::+shhyd/..oMMmhssdNmdhyyso++o++oossdo               
                                                                           `.-:::-``-:::::::/`                             +m++ymdhysyho-`-y.:ydyyo+:--.-::..+Nmmhhdmyoo+++ooossyssso/:-`               
                                                             `-::::-.....-:/:----::::----:--:/:::-`                        :d++sdmNNMNNNhsyhoymNNMMMNmdhso+:+doo+++osoosyyhhhysm+.`                     
                                           `-:::::::-.`````.//---.--:::::--..........-:::/::-..---+-                       .hssoooosyhdmy+sdo+dNNmdhyssooossysosssydhyyssoo+++od:                       
                      ``````.:::::::::---::::-.....--::::::::///////:-...-:::///////:::-.........../:.`                     `-:+syysoo+oo+omo+ooo++++ooossyyso+/-.-oyyysssssyyo.                        
                   `:++::::::--......-:::::--...............----::---....-:::///////:::-............-://`                        `-:osyysooNo+ooosyyhhmo:-.`         .d//mo-.`                          
                  `+:-:/:----::::-....-:::::-..-::::://:::::-..............-::///::-..--://////:::///::++.                            `dhhhNhhhhyssoo+d+              y/.y:                             
                  //....-:///:--://:-------....-::////////::--:////:---.--//:-...-::///:--.....---......:/                             yy+ooo++++++oood:              oh/ho                             
                  :/..............-:////::///:-://////::::////-....-::///:-...........................-//`                             `oyysyyyyyyyyso.               oy:yo                             
                   /:.......................-/o-.......---...................................:/+-..../:`                                   `..d+-ss                   +s:s+                             
                   .o......................../+..--........................................./+++-.../:                                        os.+d                   o+`os                             
                   /:.................-:::...:+.:+++-..............:/........::............-+++-....+                                         :moyh                -oym- oo      `-://-                 
                  :+...............-/ossss:...+//++++......+h......d/........sy...ss........--.....:/                                         -y:+s               +MMMMo/dm+- `+dNMMMMMmo`              
                  +:............../sssssso-..:+-+++++:+..-/omssssshd-....../ohhsssm/...:-..........+.                                         :y.+s               dMMMMMMMMMMmNMMMMMMMMMMN:             
                  :+............./ssssso/...+/../++++-+myo:.      `:oyo./ys:.     `:syhy-.......-//.                                          oo /y               +MMMMMMMMMMMMh.``+MMMMMMd             
                   +:............:oo+/-..../+..../++:/h:              :dh`            +h:.....:/-                                           .:d. s+                sMMMMMMMMMMMMNNNMMMMMMN:             
                   +-......................-o-....--sy        -syyyh+   ss      /oo+-  .d:...+.                                           -dMMm++m+`   `/ydmNmh+`  oNMMMm:mMMMMMMMMMMMMNs`              
                  //.....:/.................:+.....+h        ydooso+yh`  s+   /dsooods  /h..:/                                           `mMMMMMMMMNy/yNMMMMMMMMNo` `.:+so/.-/oyhdmdhs/`                
                 :/....-oso-................-o---..d:       od+sNMMy+m:  .d` :m+omMm+m: .d...+`                                           dMMMMMMMMMMMMms++hMMMMMMo              ```                    
                `o.....oso:................:+-:++..m.       dy+hMMNs+m:   d. hy/yMMd+m- :d...+-                                           .mMMMMMMMMMMMdossmMMMMMM+                                     
                .+.....//-................//.-+++-.h/       sd+oyyo+hy   :h  sd+oys+ds `h/..:/`                                            hMMMMmhMMMMMMMMMMMMMMm/                                      
                `o.......................-o.../+-..:d.      `shsosyh+`  `h-  `shssyh/ :h+.:/-                                              :+shmd+yoydmNMMMMMNh/`                                       
                 //.......................+:......../h-       ./+/-`   .hh/.`  `::--/so--+-`                                                  ``.``  ``.-//:-``                                         
                 .+.......................-o.........-ss-`           -oy:-:ooooooooo/-..+.                                                                                                              
                 :+.......................-o......./-..-+so/:-..--/ooo:..:s+:----.......//`                                                                                                             
                `+-.............-:+++-...-+:..-/-.........-:/++++/:-...-s/-/osoo+++oooo+.//                                                                                                             
                +:............-/ossss:../+-....-.../:...................:sy:..--:::--.-h+/-                                                                                                             
               `+-...........-osssss+..-+.................................:os+:......-/mo.                                                                                                              
                -+..........-osssss+-..-+-.............-::::::::---.........-+yho+ooosy/                                                                                                                
                 //........./ssss+:.....-+-........:+osoo+/om+/++ooooyoysoooo++m:-----+                                                                                                                 
                 +:.........-//:-........+:........//-.....h/       -m-d/```   d/.....+-                                                                                                                
                //......................//................sy...`````/h.h+---://ho.....-+                                                                                                                
               -+......................+/................./++++oooooy+.:+////::/-.....:/                                                                                                                
               .+-....................:+....-/+/.........-.........-----------:/-....-+`                                                                                                                
                `+-....-..............-+-...::-..........-:::::::::-------------:/-..oo-`                                                                                                               
                 //.-/+o/..............-+-....................................:++/-..-s/oo/`                                                                                                            
                 +-./so/-...............+/....................................-:::---:+```:os.                                                                                                          
                :+...-.....:+ooo+/:-...-o..:/++:..........................-:/:--...ys-+hs`  so                                          `-`                   `-`                                       
               `+-........ss-```.-/ossoo:-++++/-................:/+hs//:+d:`       s+ss:h+`:h`                                          oM-                   -d+                                       
                //.......:d          `-/sys++/....::::::-...-/osshm-/h.-h.       ``ysdd/.+dy`                                           +M-`::.      `-::.    `:.                                       
                 .:/o/...-d`              -oh+///-oh-``.ohoymddddN-  `sy``.-/+ssyhydy.`hh--ys`                                          oMdhoodm/  .hmyoodm+  :Mo                                       
                    ho/+/-ho            .oy.-d`    .yo/h/  ydssssym++osyyyysoooosyhymso:.hs./d+.                                        +M/    sM: mN`    oM+ :Mo                                       
                    ss`--:-d/         -hs/+ooyssssoooyh//:smyysssshNoosyhy+sNNMMMMNhh     :dho/oyo-                                     oM.    :M+ Mh     -Ms :Mo                                       
                    +myyo+/:h+       :m/:--..........---//+++ossyyhmmmNNMmshNmhyso+yh     oy.....:oso:....                              +Mo   `hN. hN-    yM: :Mo                                       
                    +d/oossyhmh:    `d::/+mdyhyyysss+++//:--............-::/++oosyyhdooo+ys....../ys:/+++od:                            oMyhyhmy-  `oddyhmh:  :Mo                                       
                    :m++omdhysshh+. :h  -ddyhddmNNooosMMNNmdhhmdhyssoo+//:::-...........--......h+.:yy+//oyd:                           `. ````       `.``     .`                                       
                    -m++omNNMMMNNNyyyhshNMMMMMMMMNo++oysooo+++sh+oosyhdmdhyms++ooossooo++:.......oh/.-odmyo+                                                                                            
                    .myso++osyhdmNo+ym+NNmmdhyssoo+oo++++oossyhhhhyysooo++om-     `````.-ss.../s-.-oy/..+ys-                                                                                            
                     `-/syyyso++ooo+sm+oooo+++++++oosyyyys+/:-yhysosooosyhs-              :y+..:ys-.-oy+-.:ss-                                                                                          
                         ``-+oyysoo+omo++++oosyyddo+:-```      `-hy+yd+/-`                 `/yo-.:ss/.-+ss+:-ss                                                                                         
                              `./mhhyNyyhhhhyssosd               oy./d                       `:sy+:-oyo-.-:yhys`                                                                                        
                                .moosyssooo+++++sd`              :d-:d`                         .+yhyhydhyyyyd`                                                                                         
                                 +hssssoooosssyyy-               .m++m.                           `.:+/`.:+o+.                                                                                          
                                  .-://+myosm:-.                 `y::h.                                                                                                                                 
                                        ss.-d                    .y--y.                                                                                                                                 
                                        :m++m`                 `.+h `d.                                                                                                                                 
                                        .h:/d.               `omNNo -m.    `:oyhddy+.                                                                                                                   
                                        .y::y.               oMMMMmhdMNh+-omMMMMMMMMNs.                                                                                                                 
                                        :h`.h`               sMMMMMMMMMMMMMNdhhmMMMMMMm`                                                                                                                
                                        so .d                .mMMMMMMMMMMMMy:-/yMMMMMMN.                                                                                                                
                                     .:+d. /y       `....`    +MMMMMNNMMMMMMMMMMMMMMMN/                                                                                                                 
                                    +NMMNssmd:`  `/ydNNNNds-  :dmNNMsoNmNMMMMMMMMMNmo.                                                                                                                  
                                   .MMMMMMMMMMmsomMMMMMMMMMMy`  `.:+o:.`-:+syhhhyo:`                                                                                                                    
                                   `mMMMMMMMMMMMMNy+/+dMMMMMMy                                                                                                                                          
                                    -NMMMMMMMMMMMNsssyNMMMMMMs                                                                                                                                          
                                     mMMMMNdMMMMMMMMMMMMMMMNo                                                                                                                                           
                                     /shmNN/yyymNNMMMMMMNdo`                                                                                                                                            
                                         `--    `-:/oo/:.                                                                                                                                               
                                                                                                                                                                                                        
                                                                                                                                                                                                             
                                                                                                                                                                                                        
                                                                                                                                  
                            Enter to try again.
                            ");
                            #endregion

                            Console.ReadLine();
                            continue;
                        }
                        continue;

                    case "s":
                        if (CurrentRoom.Exits.ContainsKey("south"))
                        {
                            go("s");
                        }
                        continue;


                    case "w":
                        if (CurrentRoom.Exits.ContainsKey("west"))
                        {
                            go("w");
                        }
                        else
                        {
                            Console.Clear();
                            #region  
                            System.Console.Write(@" 
 That Was DDDDEEEESSSSPICABLE!!!!!
                                        ___
                                __  _/:::>__
                               /:/_/::/ _/::>
                             _/:(/:::\_/::/
                            _):::::::::::::\
                          _/::::::::::::::::\____
                         /      \:::::::::/      \
                        |  ::/\  ::::::::  / \::   |
                        / ::/  \  ::::::  /   |:::/
                       /:::|    \::::::::/    |:::\
                      /::::|     \::::::/     |::::\
                    ,------:      \::::/      :------,
                   /   ___  \0    /    \ 0   / ___  \
                  : ,-' ) `  `---'      `---'   ( `-,  :
                  \_    \         '     `        \_  _/
                    \____\                         \/
                          \                  _______\________
                           \              ,-'                )
                            \           ,-    ,----------- _/

                             \             ,-'      \\ ) _/
                              (___________/__________\\ /
                               :;;;\___________________)
                        ______,:;;;;;;;;:______
                      ,;;;;;;;;;;;;;;;;;;;;;;;;\_
                     /;;;;;;;;;;;;;;;;;;;;;;;;;;;\_
                    /;;;;;;__;;;; ;;;;;; ;;;;;;;;;;\
              
                                                                                                                                                                                                                                                      
                                Press Enter to try again.         
                            ");
                            #endregion

                            Console.ReadLine();
                        }
                        continue;

                    default:
                        Console.WriteLine("Unrecognized Input!");
                        continue;

                }


            }
        }


        public void go(string direction)
        {
            if (CurrentRoom.Locked.Equals(false))
            {


                if (direction == "n")
                {
                    var newRoom = CurrentRoom.Exits["north"];
                    CurrentRoom = newRoom;
                    System.Console.WriteLine(CurrentRoom);
                    return;
                }

                else if (direction == "s")
                {
                    var newRoom = CurrentRoom.Exits["south"];
                    CurrentRoom = newRoom;
                    System.Console.WriteLine(CurrentRoom);
                    return;
                }

                else if (direction == "e")
                {
                    var newRoom = CurrentRoom.Exits["east"];
                    CurrentRoom = newRoom;
                    return;
                }

                else if (direction == "w")
                {
                    var newRoom = CurrentRoom.Exits["west"];
                    CurrentRoom = newRoom;
                    return;
                }

                else
                {
                    System.Console.WriteLine("bad input");
                    return;
                }
            }else{
                System.Console.WriteLine("IT IS LOCKED!");
            }

        }
        public string handleInput()
        {
            System.Console.Write(":");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            string inpuut = System.Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            return inpuut;

        }
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup()
        {
            var room1 = new Room("1", "A dim light courtyard with two doors.", false);
            var room2 = new Room("2", "test2yuh", false);
            var room3 = new Room("3", "Room 3", false);
            var room4 = new Room("4", "Room 4", false);
            var room5 = new Room("5", "Room 5", false);
            var room6 = new Room("6", "Escape!", false);
            room4.Exits.Add("north", room1);
            room1.Exits.Add("south", room4);
            room1.Exits.Add("north", room2);
            room2.Exits.Add("south", room1);
            room2.Exits.Add("east", room3);
            room3.Exits.Add("west", room2);
            room5.Exits.Add("west", room3);
            room5.Exits.Add("south", room6);
            room3.Exits.Add("east", room5);
            room6.Exits.Add("north", room5);
            CurrentRoom = room1;
            var lockpick = new Item("lockpick", "A universal key");
            var treasure = new Item("treasure", "treasure!");
            room4.Items.Add(lockpick);
            room4.Items.Add(treasure);





        }
        public void take(string itemName)
        {
            var Item = CurrentRoom.Items.Find(item => item.Name == itemName);
            if (Item != null)
            {
                CurrentPlayer.Inventory.Add(Item);
                CurrentRoom.Items.Remove(Item);
            }
        }
        public void UseItem(string itemName)
        {
            
        }
        public void help()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            #region 
            Console.Write(@"
---------------------------------------------------------------------------
|    COMMANDS:                                                            |
|                 quit |  q                      use item |  use          |
|                                                                         |
|      go through door |  n/e/s/w             look around |  look         |
|                                                                         |
|            Take item |  take                  Inventory |  inv          |
|                                                                         |
|                    ESCAPE the castle!   |  escape                       |
---------------------------------------------------------------------------
            ");
            #endregion
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void cheat()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            #region 
            Console.Write(@"
---------------------------------------------------------------------------
| - Go south and take treasure.                                            |
| - Go(N,N,E,E,S)                                                          |
| - use escape command with treasure to win                                |
---------------------------------------------------------------------------
            ");
            #endregion
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public Game()
        {

        }
    }
}


