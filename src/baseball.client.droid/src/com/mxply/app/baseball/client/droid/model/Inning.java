package com.mxply.app.baseball.client.droid.model;

import java.util.UUID;

public class Inning {

	public static Class<Inning> INNING_CLASS = Inning.class;
	
	UUID id;
	String name;
	
	MatchChange[] changes;
	Movement[] movements;
}
