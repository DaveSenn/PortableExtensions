﻿#region Usings

using System;
using System.Linq.Expressions;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Expression" />.
    /// </summary>
    public static class ExpressionEx
    {
        /// <summary>
        ///     Tries to get a <see cref="MemberExpression" /> from the given expression.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The given expression is of a not supported type (supported are:
        ///     <see cref="ExpressionType.MemberAccess" />, <see cref="ExpressionType.Convert" />).
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     Expression is not supported (expression is <see cref="ConstantExpression" /> or
        ///     <see cref="LambdaExpression" /> with an invalid body).
        /// </exception>
        /// <param name="expression">The expression.</param>
        /// <param name="memberExpression">The extracted <see cref="MemberExpression" />.</param>
        /// <returns>Returns true if a <see cref="MemberExpression" /> could be extracted; otherwise, false.</returns>
        public static Boolean TryGetMemberExpression( this Expression expression, out MemberExpression memberExpression )
        {
            while ( true )
            {
                expression.ThrowIfNull( nameof( expression ) );

                switch ( expression.NodeType )
                {
                    case ExpressionType.MemberAccess:
                        memberExpression = expression as MemberExpression;
                        return true;

                    case ExpressionType.Convert:
                        var operand = ( expression as UnaryExpression ).Operand;
                        //Check if operand is member expression
                        if ( operand is MemberExpression )
                        {
                            memberExpression = operand as MemberExpression;
                            return true;
                        }

                        //Operand type is not supported
                        throw new NotSupportedException(
                            $"Expressions (operand of convert) of type '{operand.NodeType}' are not supported" );

                    case ExpressionType.Constant:
                        throw new NotSupportedException(
                            "TryGetMemberExpression does not support expressions of type ConstantExpression. Consider using none-constant member." );

                    case ExpressionType.Lambda:
                        expression = ( (LambdaExpression) expression ).Body;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException( nameof( expression ), expression, $"Expressions of type '{expression.NodeType}' are not supported." );
                }
            }
        }
    }
}