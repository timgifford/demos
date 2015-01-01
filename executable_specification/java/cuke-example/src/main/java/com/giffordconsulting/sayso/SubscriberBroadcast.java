package com.giffordconsulting.sayso;

import java.util.Arrays;
import java.util.List;

public class SubscriberBroadcast {
    public List<Subscriber> send(AdvertiserDemographic advertiserDemographic) {
        return Arrays.asList(new Subscriber("Lisa"), new Subscriber("Bart"));
    }
}
