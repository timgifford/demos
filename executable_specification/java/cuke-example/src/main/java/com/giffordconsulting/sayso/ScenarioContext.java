package com.giffordconsulting.sayso;

import java.util.List;

public class ScenarioContext {
    private int margin;
    private List<Subscriber> subscribers;
    private int advertiserPrice;
    private Gender advertiserGenderFilter;

    public void setMargin(int margin) {
        this.margin = margin;
    }

    public int getMargin() {
        return margin;
    }

    public void setSubscribers(List<Subscriber> subscribers) {
        this.subscribers = subscribers;
    }

    public List<Subscriber> getSubscribers() {
        return subscribers;
    }

    public void setAdvertiserPrice(int advertiserPrice) {
        this.advertiserPrice = advertiserPrice;
    }

    public int getAdvertiserPrice() {
        return advertiserPrice;
    }

    public void setAdvertiserGenderFilter(Gender genderFilter) {
        this.advertiserGenderFilter = genderFilter;
    }

    public Gender getAdvertiserGenderFilter() {
        return advertiserGenderFilter;
    }

    public AdvertiserDemographic getAdvertiserDemographic() {
        return new AdvertiserDemographic();
    }
}
