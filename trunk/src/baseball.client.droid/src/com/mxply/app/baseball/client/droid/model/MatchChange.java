package com.mxply.app.baseball.client.droid.model;

import java.util.Date;
import java.util.UUID;

public class MatchChange {

	public static Class<MatchChange> MATCHCHANGE_CLASS = MatchChange.class;
	
	UUID id;
	UUID playerIn;
	UUID playerOut;
	Position position;
	Date time;
}
