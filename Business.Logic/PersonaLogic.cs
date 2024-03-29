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

        public bool PersonaExiste(int idLeg)
        {
            return _personaData.PersonaExiste(idLeg);
        }

        public Persona GetOneLegajo(int legajo)
        {
            return _personaData.GetOneLegajo(legajo);
        }

        public void Insert(Persona per)
        {
            _personaData.Insert(per);
        }
        public void Delete(int idPersona)
        {
            _personaData.Delete(idPersona);
        }

        public int GetIdPersona(int LegajoPersona)
        {
            int id_persona = _personaData.GetIdPersona(LegajoPersona);
            return id_persona;
        }

        public void Save(Persona persona)
        {
            _personaData.Save(persona);
        }
    }
}
