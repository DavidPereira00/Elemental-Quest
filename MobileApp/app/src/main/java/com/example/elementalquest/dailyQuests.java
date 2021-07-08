package com.example.elementalquest;


public class dailyQuests {
    private String Name;
    private String Description;
    private String Completed;
    private String Level;


    public dailyQuests(){}

    public dailyQuests(String name, String description, String completed, String level){

        this.Name=name;
        this.Description=description;
        this.Completed=completed;
        this.Level=level;
    }

    public String getName(){

        return  Name;

    }

    public void setName(String name){

        this.Name=name;

    }

    public String getDescription(){

        return Description;

    }

    public void setDescription(String description){

        this.Description=description;

    }

    public String getCompleted(){

        return  Completed;

    }

    public void setCompleted(String completed){

        this.Completed=completed;

    }

    public String getLevel(){

        return  Level;

    }

    public void setLevel(String level){

        this.Level=level;

    }
}
