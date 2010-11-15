package com.mxply.app.baseball.client.droid.model;

import java.util.Date;
import java.util.UUID;

public class Movement {

	public static Class<Movement> MOVEMENT_CLASS = Movement.class;
	
	UUID id;
	String comments;
	Date time;
	
	MovementDetail[] details;
}
