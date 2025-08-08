class Person:
    def __init__(self, name, surname, birthdate):
        self.name = name
        self.surname = surname
        self.birthdate = birthdate

class Car:
    def __init__(self, brand, model, cartype, image_path):
        self.brand = brand
        self.model = model
        self.cartype = cartype
        self.image_path = image_path

class RentalSystem:
    def __init__(self):
        self.people = []
        self.cars = []
        self.rentals = []

    def add_person(self, name, surname, birthdate):
        person = Person(name, surname, birthdate)
        self.people.append(person)

    def add_car(self, brand, model, cartype, image_path):
        car = Car(brand, model, cartype, image_path)
        self.cars.append(car)

    def show_available_cars(self, cartype):
        available_cars = []
        for car in self.cars:
            if car.cartype == cartype:
                available_cars.append(car)
        # GUI code to show available cars with images

    def rent_car(self, person_id, car_id, rental_days):
        person = self.people[person_id]
        car = self.cars[car_id]
        rental_price = self.calculate_rental_price(car, rental_days)
        rental = {
            'person': person,
            'car': car,
            'rental_days': rental_days,
            'rental_price': rental_price
        }
        self.rentals.append(rental)
        # GUI code to show rental details

    def calculate_rental_price(self, car, rental_days):
        # Calculation logic
        return rental_price

class User:
    def __init__(self, name, surname, username, password, age, email, user_type):
        self.name = name
        self.surname = surname
        self.username = username
        self.password = password
        self.age = age
        self.email = email
        self.user_type = user_type

class RegistrationSystem:
    def __init__(self):
        self.users = []

    def add_user(self, name, surname, username, password, age, email, user_type):
        user = User(name, surname, username, password, age, email, user_type)
        self.users.append(user)

    def show_registration_complete(self):
        # GUI code to show registration complete message
