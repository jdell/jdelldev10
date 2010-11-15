package com.mxply.app.baseball.client.droid.model;

import java.util.UUID;

public class Person 
{
	public static Class<Person> PERSON_CLASS = Person.class;
	
	UUID id;
	String firstName;
	String lastName;
	
	public UUID getId() {
		return id;
	}
	public void setId(UUID id) {
		this.id = id;
	}
	public String getFirstName() {
		return firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return lastName;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	
	@Override
	public String toString() {
		return "Person [firstName=" + firstName + ", lastName=" + lastName
				+ "]";
	}
}
