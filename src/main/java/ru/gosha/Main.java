package ru.gosha;

import ru.gosha.SG_Muwa.*;
import java.io.IOException;
import java.text.ParseException;

public class Main {
    public static void main(String[] args) throws Exception {
        OpenFile openFile = new OpenFile();
        System.out.println(openFile.Open("/Users/georgijfalileev/Downloads/Example2.xlsx"));
        System.out.println(openFile.Open("/Users/georgijfalileev/Downloads/Example1.xls"));
        InputSeeker inputSeeker = new InputSeeker();
        Seeker seeker = inputSeeker.setSeeker();
        System.out.print(seeker.DefaultAddress+" "+seeker.NameOfSeeker+" "+seeker.dateStart+" ");
        System.out.print(seeker.dateFinish+" "+seeker.seekerType.getStudyGroup()+" ");
        System.out.print(seeker.seekerType.getTeacher());


    }
}

