   M S B A M L   `   `   `  ????P  LCementAndConcrete.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:CementAndConcrete.WPF.ViewModelCementAndConcrete.WPF.ViewModel  5   	   ,    &CementAndConcrete.WPF.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   C	viewmodel-clr-namespace:CementAndConcrete.WPF.ViewModel     5   	      
Background#??[  5	   	   $	??600??5
   	   $	??800??6   .??5      ]? -   5        $??MainDockPanel??5   )   $??2.5 2.5 2.5 2.5q?6   .+?5   
   ? $	??Top=?6   $??90??5      .+?5      ?   ? 
ItemHeight$  40??6   $	??800??5       ? Orientation$ Vertical=?6'   .+?5      ?? $??5,10,0,0q?6   .??6*   Tables62   ?? 5      $??5,10,0,0q?6   .??6*   
Algorithms66   ?? 5      $??10, 10, 10, 0q?6   
???   ?$	??0.5q?5      $	??120??5      $??30??5       ?? DisplayMemberPath$
 Name??5      $??18(?5      ??5      ?? *	AllTables+ ?? Text 5       ?? *SelectedTableData+ ?? SelectedValue 5!      ?? *SelectedTableData+ ?? SelectedItem 5"      ?? 5#       ?? Path$ SelectedTableData?.Name?6"   5%      ?? 5'      $??10, 10, 10, 0q?6   
???   ?$	??0.5q?5)      $	??120??5*      $??30??5+      $
 Name??5,      $??18(?5-      ??5.      ?? *AllAlgorithms+ 5/      ?? *SelectedAlgorithmData+ 50      ?? *SelectedAlgorithmData+?? 51      $??0,10,0,0q?6   $??70??52      $??30??53      $??Right=?54      $??Refresh??55      $	??Top=?56      ??57      ?? *RefreshCommand+?? 58      $??70??59      $??30??5:      $
??Sort??5;      $
??Left=?5<      $??Bottom=?5=      ??5>      ?? *SortCommand+5?      ?? 5A      .+?5B      ??  ?? Right$ 10??6   
 ?? Top$ 30??5C      $??70??5D      $??30??5E      $
??Save??5F      $??right=?5G      $	??Top=?5H      ??5I      ?? *SaveCommand+5J      5L      ? 5N   
   $??Bottom=?6   $??20??5O      .+?5Q      ?? 2  ,System.Windows.Markup.XmlAttributeProperties	  XmlSpace	 preserve6I   $??Right=?6-   ???#fff made in Sigma Software =)6w   ? 5R      $
??Left=?6   $??15??5S      $??2.5,2.5,10,2.5q?5T      $??1q?5U      $??Center=?5V      $	??150??5W      5X      ? 5Z   
   $
??Left=?6   $	??220??5[      $
??Left=?5\      .+?5^      ?? $??0??6   $??Records??6'   .??5_      ]? .+?5`      ?? -   5        $??ListingItemListView??5a      $	??2.5q?5b       5c      ?? *SelectedListingData+??5d      ?? *AllListings+??5f      ?? 5g      .R?5h   "   ]? .+?5i   &   ?? $??Right=?60   $?? ??6G   ?? 5j   &   ??60   ?? *Name+5k   #   5l      5n      5o      5p      5q      ? 5s   
   -   5        $??DetailsPanel??5s   &   $??Right=?6   6:   5u      5x      