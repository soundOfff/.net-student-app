﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        private PersonaAdapter _personaData;

        public PersonaAdapter PersonaData { get { return _personaData; } set { _personaData = value; } }

        public PersonaLogic()
        {
            _personaData = new PersonaAdapter();
        }


        public List<Persona> GetAll()
        {
            return _personaData.GetAll();
        }

        public Persona GetOne(int idPer)
        {
            return _personaData.GetOne(idPer);
        }

        public Persona GetOneLegajo(int legajo)
        {
            return _personaData.GetOne(legajo);
        }


        public void Delete(int idPersona)
        {
            _personaData.Delete(idPersona);
        }

        public void Save(Persona persona)
        {
            _personaData.Save(persona);
        }
    }
}
