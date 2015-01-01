package com.giffordconsulting.sayso;

public enum Gender {
    Empty(""),
    Male("M"),
    Female("F");

    private Gender(String value) {
        this.code = value;
    }

    private String code;
}
