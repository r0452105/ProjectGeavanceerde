   M S B A M L   `   `   `  ����R  NProjectGeavanceerde_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ProjectGeavanceerde_WPF.ViewsProjectGeavanceerde_WPF.Views  5   	   0    *ProjectGeavanceerde_WPF.Views.CharEditView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:ProjectGeavanceerde_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  CharEditWindow��5   	    � Title$ CharEditView��5
   	   $	��750��6   $	��800��6+   .��5      � $��0,0,-2,0q�6   
����� � J� RenderTransformOrigin$ 0.5,0.5&�68    � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��50* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   .+�5   
   �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Naam��5       %  !MaterialDesignFloatingHintTextBox#��[  5       $��0��5!      $��1��6!   ��5      �� *SelectedCharacter.Name+ �� ValidatesOnDataErrors . 5!   !   �� 5"   
    �� SelectedValuePath$ GenderID��5$      $ Gender��5%       & "MaterialDesignFloatingHintComboBox#��[ 5&      $��1��5'      $��1��6    $��50��60   $
��0,10q�6<   ��5"      �� *	Genders+ .  �� SelectedValue 5#      �� *SelectedCharacter.GenderID+ . 5'   <   �� 5(   
   $ 
Verjaardag��5)      #��[  5*      $��2��5+      $��1��6!   ��5(      �� *SelectedCharacter.Birthday+	 �� StringFormat$	 m�� . 5+   !   �� 5,   
   $ Bounty��5-      #��[  5.      $��3��5/      $��1��6!   ��5,      �� *SelectedCharacter.Bounty+$	 {0:N0}�� . 5/   !   �� 50   
   $ 
DevilFruit��51      #��[  52      $��4��53      $��1��6!   ��50      �� *SelectedCharacter.DevilFruit+$	 m�� . 53   !   �� 54   
   $ HakiID��56      $��1��57      $
 Haki��58      #��[ 59      $��5��5:      $��50��6    $
��0,10q�6,   ��54      �� *Hakis+ .  55      �� *SelectedCharacter.HakiID+ . 5:   ,   �� 5;   
   $ BloodtypeID��5=      $��1��5>      $ 	Bloodtype��5?      #��[ 5@      $��6��5A      $��50��6    $
��0,10q�6,   ��5;      �� *
Bloodtypes+ .  5<      �� *SelectedCharacter.BloodtypeID+ . 5A   ,   �� 5B   
   $ 	SpeciesID��5D      $ Species��5E      #��[ 5F      $��7��5G      $��1��6    $��50��60   $
��0,10q�6<   ��5B      �� *	Soorten+ .  5C      �� *SelectedCharacter.SpeciesID+ . 5G   <   �� 5H   
   $��20(�60   
������$��8��6V   $��1��6c   $��10q�6s   ��6   �� *Foutmelding+6�   �� 5I   
   $��Character Bewerken��6   $��9��6/   $��1��6<   
���   ����#00b4d8$��30(�6u   $��3q�6�   $��5q�6�   $
��Auto��6  ��6�   �� *CloseWindowCommandCharEdit+
 �� Mode$
 OneWay=���6�   ��  �� ElementName$ CharEditWindow��6  �� 5J   
   $��Terug naar Characters��6   $��10��62   $��1��6@   
���   ����#00b4d8$��30(�6y   $��3q�6�   $��5q�6�   $
��Auto��6  ��6�   �� *CloseWindowCommandCharBack+$
 OneWay=���6�   �� $ CharEditWindow��6  5K      5L      